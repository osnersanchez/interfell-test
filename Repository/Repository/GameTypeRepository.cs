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
    public class GameTypeRepository : BaseRepository<GameType>, IGameTypeRepository
    {
        ApiContext _dataContext;

        public GameTypeRepository(ApiContext context)
            : base(context)
        {
            _dataContext = context;
        }

        IQueryable<GameType> IGameTypeRepository.GetList()
        {
            return _dataContext.GameTypes.Include(g=> g.Games).AsQueryable();
        }
    }
}
