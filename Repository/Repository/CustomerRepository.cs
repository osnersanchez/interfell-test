using Domain;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        ApiContext _dataContext;

        public CustomerRepository(ApiContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IQueryable<Customer> GetList()
        {
            return _dataContext.Customers.AsQueryable();
        }
    }
}
