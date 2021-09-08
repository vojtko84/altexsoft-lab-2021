using System.Collections.Generic;
using AspMyDelivery.API.ViewModels;
using AutoMapper;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MyDelivery.Interfaces;

namespace AspMyDelivery.API.Controllers
{
    public class ProductMvcController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductMvcController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return View(productsDto);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productService.GetProduct(id);
            var productDto = _mapper.Map<ProductViewModel>(product);

            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var productEntity = _mapper.Map<Product>(product);
            productEntity.Id = id;
            _productService.UpdateProduct(productEntity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProduct(id);
            var productEntity = _mapper.Map<EditProductViewModel>(product);

            return View(productEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var productEntity = _mapper.Map<Product>(product);
            _productService.AddProduct(productEntity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productForDelete = _productService.GetProduct(id);

            return View(productForDelete);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _productService.DeleteProduct(product.Id);

            return RedirectToAction("Index");
        }
    }
}