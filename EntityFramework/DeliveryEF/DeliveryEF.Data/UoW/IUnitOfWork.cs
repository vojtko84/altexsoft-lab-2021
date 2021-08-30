using DeliveryEF.Data.Repositories;
using DeliveryEF.Domain.Models;

namespace DeliveryEF.Data.UoW
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<DeliveryAddress> DeliveryAddresses { get; }
        IRepository<Order> Orders { get; }

        void Save();
    }
}