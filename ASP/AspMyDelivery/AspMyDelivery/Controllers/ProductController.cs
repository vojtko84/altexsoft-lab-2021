using System.Collections.Generic;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Loggers;

namespace AspMyDelivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var productController = new ProductService(new UnitOfWork(), new Logger(), new Cache());

            var products = productController.GetProducts();

            return products;
        }
    }

    //GET api/Product
    //GET api/Product/id
    //POST api/Product
    //PUT api/Product
    //DELETE api/Product/id
    //GET api/Category
    //GET api/Category/id
    //POST api/Category
    //PUT api/Category
    //DELETE api/Category/id
    //GET api/Provider
    //GET api/Provider/id
    //POST api/Provider
    //PUT api/Provider
    //DELETE api/Provider/id
    //GET api/Customer
    //GET api/Customer/id
    //POST api/Customer
    //PUT api/Customer
    //DELETE api/Customer/id
    //GET api/DeliveryAddress
    //GET api/DeliveryAddress/id
    //POST api/DeliveryAddress
    //PUT api/DeliveryAddress
    //DELETE api/DeliveryAddress/id
    //GET api/DeliveryMan
    //GET api/DeliveryMan/id
    //POST api/DeliveryMan
    //PUT api/DeliveryMan
    //DELETE api/DeliveryMan/id
    //GET api/DeliveryRate
    //GET api/DeliveryRate/id
    //POST api/DeliveryRate
    //PUT api/DeliveryRate
    //DELETE api/DeliveryRate/id
    //GET api/Order
    //GET api/Order/id
    //POST api/Order
    //PUT api/Order
    //DELETE api/Order/id
}