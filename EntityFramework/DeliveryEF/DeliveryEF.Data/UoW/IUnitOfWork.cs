using DeliveryEF.Data.Repositories;
using DeliveryEF.Domain.Models;

namespace DeliveryEF.Data.UoW
{
    public interface IUnitOfWork
    {
        EFRepository<Product> Products { get; }
        EFRepository<Category> Categories { get; }
        EFRepository<DeliveryAddress> DeliveryAddresses { get; }
        EFRepository<Order> Orders { get; }

        void Save();
    }
}