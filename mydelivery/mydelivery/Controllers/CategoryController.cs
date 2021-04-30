using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Collections.Generic;
using System.Linq;

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
                Id = context.Categories.Max(s => s.Id) + 1,
                Name = name
            };
            context.Categories.Add(category);
            context.Save();
        }
    }
}