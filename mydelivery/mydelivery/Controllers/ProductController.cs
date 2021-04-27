using Mydelivery.Data;
using Mydelivery.Interfaces;
using Mydelivery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mydelivery.Controllers
{
    public class ProductController : IProductController
    {
        private readonly IContext context;

        public ProductController(IContext context)
        {
            this.context = context;
        }

        public void AddProduct(string name, string description, int categoryId, decimal price, int sellerId)
        {
            var product = new Product
            {
                Id = context.Products.Count + 1,
                Name = name,
                Description = description,
                CategoryId = categoryId,
                Price = price,
                SellerId = sellerId
            };
            context.Products.Add(product);
            context.Save();
        }

        public IList<Product> GetProducts()
        {
            return context.Products;
        }

        public Product GetProduct(int id)
        {
            return context.Products.ElementAt(id - 1);
        }

        public void DeleteProduct(int id)
        {
            context.Products.RemoveAt(id - 1);
        }
    }
}