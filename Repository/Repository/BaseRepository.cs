using Repository.Repository.Interfaces;
using System;
using System.Data.Entity;

namespace Repository.Repository
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        protected ApiContext _context;

        public BaseRepository(ApiContext context)
        {
            _context = context;
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Insert(T item)
        {
            _context.Set<T>().Add(item);
        }

        public virtual void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public virtual void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
