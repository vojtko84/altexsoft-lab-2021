using MyDelivery.Enums;
using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyDelivery.Controllers
{
    public class OrderController : IOrderController
    {
        private readonly IContext context;
        private readonly ILogger logger;
        private readonly ICache cache;
        private readonly IPriceController priceController;

        public OrderController(IContext context, ILogger logger, ICache cache, IPriceController priceController)
        {
            this.context = context;
            this.logger = logger;
            this.cache = cache;
            this.priceController = priceController;
        }

        public Order AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress)
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
            cache.Add<Order>(order.Id, order);
            logger.SaveIntoFile($"Added order ID: {order.Id}");
            return order;
        }

        public Task<decimal> GetRecalculatePriceInUSD(Order order)
        {
            decimal totalPrice = default;
            foreach (var product in order.Products)
            {
                totalPrice += product.Price;
            }
            return priceController.GetPriceForCurrency(CurrencyNames.USD, totalPrice);
        }
    }
}