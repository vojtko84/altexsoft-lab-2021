using System.Collections.Generic;
using AspMyDelivery.API.DataTransferObjects;
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
        public IEnumerable<CategoryDto> Get()
        {
            var categories = _categoryService.GetCategories();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }

        [HttpGet("{id}")]
        public CategoryDto Get(int id)
        {
            var category = _categoryService.GetCategory(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        [HttpPost]
        public void Post([FromBody] CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _categoryService.AddCategory(categoryEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryForCreationDto category)
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