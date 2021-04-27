using Mydelivery.Data;
using Mydelivery.Interfaces;
using Mydelivery.Models;

namespace Mydelivery.Controllers
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
                Id = context.Orders.Count + 1,
                BuyerId = buyerId
            };

            order.Products.Add(product);
            order.DeliveryAddress = deliveryAddress;
            context.Orders.Add(order);
            context.Save();
        }
    }
}