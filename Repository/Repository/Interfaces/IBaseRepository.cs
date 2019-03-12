using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(int id);
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
    }
}
