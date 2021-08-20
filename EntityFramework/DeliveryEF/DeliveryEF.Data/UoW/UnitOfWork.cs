using DeliveryEF.Data.Repositories;
using DeliveryEF.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEF.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context = new DataContext();
        private EFRepository<Product> productRepository;

        public EFRepository<Product> Products
        {
            get
            {
                if (productRepository is null)
                {
                    return productRepository = new EFRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}