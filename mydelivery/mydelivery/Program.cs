using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Loggers;
using System.Threading.Tasks;

namespace MyDelivery
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var dataManager = new JsonManager();
            var context = new Context(dataManager);
            var logger = new Logger();
            var cache = new Cache();
            var userController = new UserController();
            var priceController = new PriceController();
            var productController = new ProductController(context, logger, cache);
            var orderController = new OrderController(context, logger, cache, priceController);
            var deliveryAddressController = new DeliveryAddressController(context, logger, cache);
            var categoryController = new CategoryController(context, logger);

            var presenter = new Presenter(context, userController, productController, orderController, categoryController, deliveryAddressController);

            await presenter.Run();
        }
    }
}