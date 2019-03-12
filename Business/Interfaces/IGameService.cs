using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IGameService
    {
        Game Get(int id);
        List<GameDTO> GetList();
        GameDTO Add(GameAddOrEditDTO game);
        GameDTO Put(GameAddOrEditDTO game);
        void Delete(int id);
        List<GameTypeDTO> GetGameTypes();
    }
}
