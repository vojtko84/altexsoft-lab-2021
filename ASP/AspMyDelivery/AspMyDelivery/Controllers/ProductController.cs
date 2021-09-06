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
        public IEnumerable<ProductViewModel> Get()
        {
            var products = _productService.GetProducts();
            var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return productsViewModel;
        }

        [HttpGet("{id}")]
        public ProductViewModel Get(int id)
        {
            var product = _productService.GetProduct(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);

            return productViewModel;
        }

        [HttpPost]
        public void Post([FromBody] ProductForCreationViewModel product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _productService.AddProduct(productEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductForCreationViewModel product)
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