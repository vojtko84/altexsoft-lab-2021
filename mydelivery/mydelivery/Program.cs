using MyDelivery.Controllers;
using MyDelivery.Data;

namespace MyDelivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new Context();
            var userController = new UserController();
            var productController = new ProductController(context);
            var orderController = new OrderController(context);
            var deliveryAddressController = new DeliveryAddressController(context);
            var categoryController = new CategoryController(context);

            var presenter = new Presenter(context, userController, productController, orderController, categoryController, deliveryAddressController);

            presenter.Run();
        }
    }
}