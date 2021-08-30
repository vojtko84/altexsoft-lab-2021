using System.Collections.Generic;
using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();

        void AddCategory(string name);
    }
}