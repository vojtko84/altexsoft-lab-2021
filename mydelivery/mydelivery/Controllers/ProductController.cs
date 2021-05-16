using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IContext context;
        private readonly ILogger logger;

        public ProductController(IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void AddProduct(string name, string description, int categoryId, decimal price, int sellerId)
        {
            var product = new Product
            {
                Id = context.Products.Max(s => s.Id) + 1,
                Name = name,
                Description = description,
                CategoryId = categoryId,
                Price = price,
                SellerId = sellerId
            };
            context.Products.Add(product);
            context.Save();
            logger.SaveIntoFile($"Added product ID: {product.Id}");
        }

        public IList<Product> GetProducts()
        {
            return context.Products;
        }

        public Product GetProduct(int id)
        {
            return context.Products.Where(product => product.Id == id).FirstOrDefault();
        }

        public void DeleteProduct(int id)
        {
            context.Products.Remove(GetProduct(id));
            logger.SaveIntoFile($"Deleted product ID: {id}");
        }
    }
}