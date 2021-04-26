using Mydelivery.Data;
using Mydelivery.Models;
using System.Collections.Generic;

namespace Mydelivery.Controllers
{
    public class CategoryController
    {
        private readonly Context context;

        public CategoryController(Context context)
        {
            this.context = context;
        }

        public IList<Category> GetCategories()
        {
            return context.Categories;
        }

        public void AddCategory(string name)
        {
            var category = new Category
            {
                Id = context.Categories.Count + 1,
                Name = name
            };
            context.Categories.Add(category);
            context.Save();
        }
    }
}