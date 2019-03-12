using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GameRent
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int GameId { get; set; }
        public DateTime RentalDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Game Game { get; set; }
    }
}
