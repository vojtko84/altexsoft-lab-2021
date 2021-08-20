using System.Collections.Generic;
using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface IProductController
    {
        void AddProduct(string name, string description, int categoryId, decimal price, int sellerId);

        IList<Product> GetProducts();

        Product GetProduct(int id);

        void DeleteProduct(int id);
    }
}