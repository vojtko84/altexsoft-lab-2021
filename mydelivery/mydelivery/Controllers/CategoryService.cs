using System.Collections.Generic;
using System.Linq;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CategoryService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IList<Category> GetCategories()
        {
            return _unitOfWork.Categories.GetAll().ToList();
        }

        public void AddCategory(string name)
        {
            var category = new Category
            {
                Name = name
            };
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Added category {category.Name}");
        }
    }
}