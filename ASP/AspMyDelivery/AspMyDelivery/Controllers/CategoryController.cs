using System.Collections.Generic;
using AspMyDelivery.API.ViewModels;
using AutoMapper;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MyDelivery.Interfaces;

namespace AspMyDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> Get()
        {
            var categories = _categoryService.GetCategories();
            var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return categoriesViewModel;
        }

        [HttpGet("{id}")]
        public CategoryViewModel Get(int id)
        {
            var category = _categoryService.GetCategory(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

            return categoryViewModel;
        }

        [HttpPost]
        public void Post([FromBody] CreateCategoryViewModel category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _categoryService.AddCategory(categoryEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateCategoryViewModel category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            categoryEntity.Id = id;
            _categoryService.UpdateCategory(categoryEntity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}