using System.Collections.Generic;

using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();

        void AddCategory(Category category);

        Category GetCategory(int id);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);
    }
}