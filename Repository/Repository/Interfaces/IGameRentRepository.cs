using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IGameRentRepository : IBaseRepository<GameRent>, IDisposable
    {
        IQueryable<GameRent> GetListIncludeCustomer();
        IQueryable<GameRent> GetListIncludeGame();
    }
}
