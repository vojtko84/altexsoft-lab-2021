using MyDelivery.Controllers;
using MyDelivery.Data;
using MyDelivery.Loggers;

namespace MyDelivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new Context();
            var logger = new Logger();
            var userController = new UserController();
            var productController = new ProductController(context, logger);
            var orderController = new OrderController(context, logger);
            var deliveryAddressController = new DeliveryAddressController(context, logger);
            var categoryController = new CategoryController(context, logger);

            var presenter = new Presenter(context, userController, productController, orderController, categoryController, deliveryAddressController);

            presenter.Run();
        }
    }
}