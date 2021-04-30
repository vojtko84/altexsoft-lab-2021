using MyDelivery.Models;
using System.Collections.Generic;

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