using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class GameRentSumaryDTO
    {
        public GameRentSumaryDTO()
        {
            ActiveCustomers = 0;
            LastRegisteredCustomer = "Empty";
            GameRentHistory = new List<GameRentDTO>();
            AmountGamePerGender = new List<AmountGamePerGenderDTO>();
        }

        public int ActiveCustomers { get; set; }
        public string LastRegisteredCustomer { get; set; }
        public List<GameRentDTO> GameRentHistory { get; set; }
        public List<AmountGamePerGenderDTO> AmountGamePerGender { get; set; }
    }
}
