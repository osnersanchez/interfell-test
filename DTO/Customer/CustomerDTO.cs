using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        public CustomerDTO()
        {
        }

        public int Id { get; set; }
        public int CustomerCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public static explicit operator CustomerDTO (Customer model)
        {
            CustomerDTO dto = new CustomerDTO();

            if(model != null)
            {
                dto.Id = model.Id;
                dto.Name = model.Name;
                dto.Phone = model.Phone;
                dto.Address = model.Address;
                dto.CustomerCode = model.CustomerCode;
            }

            return dto;
        }
    }
}
