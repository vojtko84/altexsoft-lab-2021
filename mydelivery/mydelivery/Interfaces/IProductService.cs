using System.Collections.Generic;
using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);

        IList<Product> GetProducts();

        Product GetProduct(int id);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);
    }
}