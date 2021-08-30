using DeliveryEF.Data.Repositories;
using DeliveryEF.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEF.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context = new DataContext();
        private IRepository<Product> _productRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<DeliveryAddress> _deliveryAddressRepository;
        private IRepository<Order> _orderRepository;

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}