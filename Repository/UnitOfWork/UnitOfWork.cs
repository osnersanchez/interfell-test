using Domain;
using Repository.Repository;
using Repository.Repository.Interfaces;
using Repository.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApiContext _context;
        private bool disposed = false;

        public UnitOfWork()
        {
            _context = new ApiContext();
        }

        private CustomerRepository _customerRepository;
        private GameRepository _gameRepository;
        private GameRentRepository _gameRentRepository;
        private GameTypeRepository _gameTypeRepository;

        public ICustomerRepository CustomerRepository
        {
            get { return (_customerRepository == null ? _customerRepository = new CustomerRepository(_context) : _customerRepository); }
        }

        public IGameRepository GameRepository
        {
            get { return (_gameRepository == null ? _gameRepository = new GameRepository(_context) : _gameRepository); }
        }

        public IGameRentRepository GameRentRepository
        {
            get { return (_gameRentRepository == null ? _gameRentRepository = new GameRentRepository(_context) : _gameRentRepository); }
        }

        public IGameTypeRepository GameTypeRepository
        {
            get { return (_gameTypeRepository == null ? _gameTypeRepository = new GameTypeRepository(_context) : _gameTypeRepository); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
