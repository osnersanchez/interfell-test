using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameRentSumaryByCustomerDTO
    {
        public GameRentSumaryByCustomerDTO()
        {
            Customer = new CustomerDTO();
            GameRentHistory = new List<GameRentByCustomerDTO>();
            MostRentedGames = new List<MostRentedGamesDTO>();
        }

        public CustomerDTO Customer { get; set; }
        public List<GameRentByCustomerDTO> GameRentHistory { get; set; }
        public List<MostRentedGamesDTO> MostRentedGames { get; set; }

    }
}
