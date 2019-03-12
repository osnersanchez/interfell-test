using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameRentByCustomerDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int AmountOfRental { get; set; }
        public string LastRentalDate { get; set; }
    }
}
