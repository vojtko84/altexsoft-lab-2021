using MyDelivery.Models;
using System.Collections.Generic;

namespace MyDelivery.Interfaces
{
    public interface ICategoryController
    {
        IList<Category> GetCategories();

        void AddCategory(string name);
    }
}