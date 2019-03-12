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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        ApiContext _dataContext;

        public GameRepository(ApiContext context)
            : base(context)
        {
            _dataContext = context;
        }

        IQueryable<Game> IGameRepository.GetList()
        {
            return _dataContext.Games.Include(g => g.GameType).AsQueryable();
        }
    }
}
