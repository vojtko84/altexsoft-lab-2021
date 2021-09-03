using System.Collections.Generic;
using System.Linq;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly ICache _cache;

        public ProductService(IUnitOfWork unitOfWork, ILogger logger, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _cache = cache;
        }

        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Create(product);
            _unitOfWork.Save();
            _cache.Add(product.Id, product);
            _logger.SaveIntoFile($"Added product ID: {product.Id}");
        }

        public IList<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll().ToList();
        }

        public Product GetProduct(int id)
        {
            return _cache.GetOrCreate(id, () => _unitOfWork.Products.GetById(id));
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.Products.DeleteById(id);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Deleted product ID: {id}");
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProduct(product.Id);
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Description = product.Description;

            _unitOfWork.Products.Update(productToUpdate);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Update product ID: {product.Id}");
        }
    }
}