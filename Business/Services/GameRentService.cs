using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.UnitOfWork.Interfaces;
using DTO;

namespace Business.Services
{
    public class GameRentService : IGameRentService
    {
        private IUnitOfWork _unitOfWork;

        public GameRentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<GameRentDTO> GetAll()
        {
            List<GameRentDTO> history = new List<GameRentDTO>();

            history = _unitOfWork.GameRentRepository.GetListIncludeCustomer()
                        .OrderBy(x => x.GameId)
                        .GroupBy(x => new { x.GameId, x.CustomerId})
                        .ToList()
                        .Select(r => new GameRentDTO
                        {
                            GameId = r.Key.GameId,
                            GameName = r.FirstOrDefault().Game.Name,
                            Customer = r.FirstOrDefault().Customer.Name,
                            CustomerCode = r.FirstOrDefault().Customer.CustomerCode,
                            AmountOfRental = r.DefaultIfEmpty().Count(),
                            LastRentalDate = r.LastOrDefault().RentalDate.ToShortDateString()
                        }).OrderByDescending(x => x.LastRentalDate).ToList();

            return history;
        }

        public List<GameRentByCustomerDTO> GetAllByCustomer(int customerId)
        {
            List<GameRentByCustomerDTO> history = new List<GameRentByCustomerDTO>();

            history = _unitOfWork.GameRentRepository.GetListIncludeGame()
                        .Where(x => x.CustomerId == customerId)
                        .OrderBy(x => x.GameId)
                        .GroupBy(x => x.GameId)
                        .ToList()
                        .Select(r => new GameRentByCustomerDTO
                        {
                            GameId = r.Key,
                            GameName = r.FirstOrDefault(x => x != null)?.Game.Name ?? "",
                            AmountOfRental = r.DefaultIfEmpty().Count(),
                            LastRentalDate = r.LastOrDefault(x => x != null)?.RentalDate.ToShortDateString() ?? ""
                        }).OrderByDescending(x => x.LastRentalDate).ToList();

            return history;
        }

        public GameRentSumaryDTO GetSumary()
        {
            GameRentSumaryDTO sumary = new GameRentSumaryDTO();

            sumary.GameRentHistory = GetAll();
            sumary.ActiveCustomers = _unitOfWork.CustomerRepository.GetList().ToList().Count();
            sumary.LastRegisteredCustomer = _unitOfWork.CustomerRepository.GetList().ToList().LastOrDefault(m=> m.Name != null)?.Name ?? "No users";
            sumary.AmountGamePerGender = _unitOfWork.GameTypeRepository.GetList()
                .OrderBy(x => x.Id)
                .GroupBy(x => x.Id)
                .ToList()
                .Select(x => new AmountGamePerGenderDTO
                {
                    Game = x.FirstOrDefault().Title,
                    Quantity = x.FirstOrDefault().Games.Count()
                }).ToList();

            return sumary;
        }

        public GameRentSumaryByCustomerDTO GetSumaryByCustomer(int customerCode)
        {
            GameRentSumaryByCustomerDTO sumary = new GameRentSumaryByCustomerDTO();

            var customer = _unitOfWork.CustomerRepository.GetList()
           .Where(x => x.CustomerCode == customerCode)
           .FirstOrDefault();

            if (customer == null)
            {
                return sumary;
            }


            sumary.Customer = (CustomerDTO) _unitOfWork.CustomerRepository.Get(customer.Id);
            sumary.GameRentHistory = GetAllByCustomer(customer.Id);
            sumary.MostRentedGames = GetAllByCustomer(customer.Id)
                .OrderByDescending(x => x.AmountOfRental)
                .Select(g => new MostRentedGamesDTO { Game = g.GameName, Quantity = g.AmountOfRental })
                .Take(3)
                .ToList();

            return sumary;
        }
    }
}
