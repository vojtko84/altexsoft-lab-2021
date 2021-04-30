using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Collections.Generic;

namespace MyDelivery.Controllers
{
    public class CategoryController : ICategoryController
    {
        private readonly IContext context;

        public CategoryController(IContext context)
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