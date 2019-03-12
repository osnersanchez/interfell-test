using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IGameRentService
    {
        List<GameRentDTO> GetAll();
        List<GameRentByCustomerDTO> GetAllByCustomer(int customerId);
        GameRentSumaryDTO GetSumary();
        GameRentSumaryByCustomerDTO GetSumaryByCustomer(int customerCode);

    }
}
