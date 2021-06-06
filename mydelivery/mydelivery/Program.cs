using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Loggers;

namespace MyDelivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dataManager = new JsonManager();
            var context = new Context(dataManager);
            var logger = new Logger();
            var cache = new Cache();
            var userController = new UserController();
            var productController = new ProductController(context, logger, cache);
            var orderController = new OrderController(context, logger, cache);
            var deliveryAddressController = new DeliveryAddressController(context, logger, cache);
            var categoryController = new CategoryController(context, logger);

            var presenter = new Presenter(context, userController, productController, orderController, categoryController, deliveryAddressController);

            presenter.Run();
        }
    }
}