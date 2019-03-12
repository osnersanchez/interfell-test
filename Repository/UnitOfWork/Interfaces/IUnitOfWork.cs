using Domain;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
       
        ICustomerRepository CustomerRepository { get; }
        IGameRepository GameRepository { get; }
        IGameTypeRepository GameTypeRepository { get; }
        IGameRentRepository GameRentRepository { get; }
    }
}
