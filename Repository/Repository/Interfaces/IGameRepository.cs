using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>, IDisposable
    {
        IQueryable<Game> GetList();
    }
}
