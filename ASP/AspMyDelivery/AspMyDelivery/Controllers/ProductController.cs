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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            var products = _productService.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productsDto;
        }

        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            var product = _productService.GetProduct(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        [HttpPost]
        public void Post([FromBody] ProductForCreateDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _productService.AddProduct(productEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductForEditDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            productEntity.Id = id;
            _productService.UpdateProduct(productEntity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}