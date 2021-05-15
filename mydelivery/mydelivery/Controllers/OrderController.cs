using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IContext context;
        private readonly ILogger logger;

        public OrderController(IContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress)
        {
            var order = new Order
            {
                Id = context.Orders.Max(s => s.Id) + 1,
                BuyerId = buyerId
            };

            order.Products.Add(product);
            order.DeliveryAddress = deliveryAddress;
            context.Orders.Add(order);
            context.Save();
            logger.SaveIntoFile($"Added order ID: {order.Id}");
        }
    }
}