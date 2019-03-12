using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICustomerService
    {
        CustomerDTO Get(int id);
        List<CustomerDTO> GetList();
        CustomerDTO Add(CustomerEditDTO customer);
        CustomerDTO Put(CustomerEditDTO customer);
        void Delete(int id);
        
    }
}
