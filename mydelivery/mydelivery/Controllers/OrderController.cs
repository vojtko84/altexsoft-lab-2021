using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IContext context;

        public OrderController(IContext context)
        {
            this.context = context;
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
        }
    }
}