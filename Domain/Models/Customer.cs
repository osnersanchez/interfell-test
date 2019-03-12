using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public Customer()
        {
            RentedGames = new HashSet<GameRent>();
        }

        public int Id { get; set; }
        public int CustomerCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<GameRent> RentedGames { get; set; }
    }
}
