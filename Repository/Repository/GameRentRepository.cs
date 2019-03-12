using Domain;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GameRentRepository : BaseRepository<GameRent>, IGameRentRepository
    {
        ApiContext _dataContext;

        public GameRentRepository(ApiContext context)
            : base(context)
        {
            _dataContext = context;
        }

        IQueryable<GameRent> IGameRentRepository.GetListIncludeGame()
        {
            return _dataContext.RentedGames.Include(g => g.Game).AsQueryable();
        }

        IQueryable<GameRent> IGameRentRepository.GetListIncludeCustomer()
        {
            return _dataContext.RentedGames
                .Include(g => g.Customer)
                .Include(g => g.Game).AsQueryable();
        }
    }
}
