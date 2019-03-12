using Domain;
using DTO;
using Repository.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CustomerDTO Add(CustomerEditDTO customer)
        {
            Customer cust = new Customer()
            {
                Name = customer.Name,
                CustomerCode = new Random().Next(),
                Address = customer.Address,
                Phone = customer.Phone
            };

            _unitOfWork.CustomerRepository.Insert(cust);
            _unitOfWork.Commit();

            return (CustomerDTO) cust;
        }

        public void Delete(int id)
        {
            Customer cust = _unitOfWork.CustomerRepository.Get(id);
            _unitOfWork.CustomerRepository.Delete(cust);
            _unitOfWork.Commit();
        }

        public CustomerDTO Get(int id)
        {
            return (CustomerDTO)_unitOfWork.CustomerRepository.Get(id);
        }

        public List<CustomerDTO> GetList()
        {
           return _unitOfWork.CustomerRepository.GetList().ToList().Select(x => (CustomerDTO) x).ToList();
        }

        public CustomerDTO Put(CustomerEditDTO customer)
        {
            Customer cust = _unitOfWork.CustomerRepository.Get(customer.Id);

            cust.Address = customer.Address;
            cust.Name = customer.Name;
            cust.Phone = customer.Phone;

            _unitOfWork.CustomerRepository.Update(cust);
            _unitOfWork.Commit();

            return (CustomerDTO) cust;
        }
    }
}
