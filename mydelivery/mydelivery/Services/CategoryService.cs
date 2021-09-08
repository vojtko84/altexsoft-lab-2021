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
        private readonly IMyLogger _logger;

        public CategoryService(IUnitOfWork unitOfWork, IMyLogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IList<Category> GetCategories()
        {
            return _unitOfWork.Categories.GetAll().ToList();
        }

        public Category GetCategory(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Added category {category.Name}");
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategory(category.Id);
            categoryToUpdate.Name = category.Name;

            _unitOfWork.Categories.Update(categoryToUpdate);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Update category ID: {category.Id}");
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.Categories.DeleteById(id);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Deleted category ID: {id}");
        }
    }
}