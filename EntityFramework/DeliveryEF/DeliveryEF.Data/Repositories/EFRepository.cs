using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEF.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Find<T>(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}