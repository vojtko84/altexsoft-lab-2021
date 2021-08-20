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
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var productController = new ProductController(new UnitOfWork(), new Logger(), new Cache());

            var products = productController.GetProducts();

            return products;
        }
    }
}