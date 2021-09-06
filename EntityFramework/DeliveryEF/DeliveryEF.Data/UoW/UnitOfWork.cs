using DeliveryEF.Data.Repositories;
using DeliveryEF.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEF.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IRepository<Product> _productRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<DeliveryAddress> _deliveryAddressRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<Provider> _providerRepository;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_productRepository is null)
                {
                    return _productRepository = new EFRepository<Product>(_context);
                }
                return _productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository is null)
                {
                    return _categoryRepository = new EFRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public IRepository<DeliveryAddress> DeliveryAddresses
        {
            get
            {
                if (_deliveryAddressRepository is null)
                {
                    return _deliveryAddressRepository = new EFRepository<DeliveryAddress>(_context);
                }
                return _deliveryAddressRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository is null)
                {
                    return _orderRepository = new EFRepository<Order>(_context);
                }
                return _orderRepository;
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                if (_providerRepository is null)
                {
                    return _providerRepository = new EFRepository<Provider>(_context);
                }
                return _providerRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}