using System.Collections.Generic;
using Delivery.Models;

namespace Delivery.Repositories
{
    public interface IRepository
    {
        List<Category> GetCategories();

        Category GetCategoryById(int id);

        int AddCategory(Category product);

        bool UpdateCategory(Category product);

        bool DeleteCategory(int id);

        int AddCategoryWithObjects(Category category);

        bool DeleteCategoryWithObjects(int id);

        Category GetCategoryByIdWithObjects(int id);

        List<Category> GetCategoriesWithObjects();
    }
}