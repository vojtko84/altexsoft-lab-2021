using System.Collections.Generic;

namespace DeliveryEF.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteById(int id);
    }
}