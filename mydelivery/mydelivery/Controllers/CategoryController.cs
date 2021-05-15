using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class CategoryController : ICategoryController
    {
        private readonly IContext context;
        private readonly ILogger logger;

        public CategoryController(IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
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
            logger.SaveIntoFile($"Added category {category.Name}");
        }
    }
}