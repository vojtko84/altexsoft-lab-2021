using System.Collections.Generic;
using System.Linq;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger logger;
        private readonly ICache cache;

        public ProductController(IUnitOfWork unitOfWork, ILogger logger, ICache cache)
        {
            _unitOfWork = unitOfWork;
            this.logger = logger;
            this.cache = cache;
        }

        public void AddProduct(string name, string description, int categoryId, decimal price, int sellerId)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                CategoryId = categoryId,
                Price = price,
                ProviderId = sellerId,
            };
            _unitOfWork.Products.Create(product);
            _unitOfWork.Save();
            cache.Add(product.Id, product);
            logger.SaveIntoFile($"Added product ID: {product.Id}");
        }

        public IList<Product> GetProducts()
        {
            return _unitOfWork.Products.GetAll().ToList();
        }

        public Product GetProduct(int id)
        {
            return cache.GetOrCreate(id, () => _unitOfWork.Products.GetById(id));
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.Products.DeleteById(id);
            logger.SaveIntoFile($"Deleted product ID: {id}");
        }
    }
}