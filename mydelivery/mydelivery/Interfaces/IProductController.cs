using System.Collections.Generic;
using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface IProductController
    {
        void AddProduct(string name, string description, int categoryId, decimal price, int sellerId);

        IList<Product> GetProducts();

        Product GetProduct(int id);

        void DeleteProduct(int id);
    }
}