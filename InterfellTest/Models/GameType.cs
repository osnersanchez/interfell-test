using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfellTest
{
    public class GameType
    {
        public GameType()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Title { get; set; }


        public virtual ICollection<Game> Games { get; set; }
    }
}
