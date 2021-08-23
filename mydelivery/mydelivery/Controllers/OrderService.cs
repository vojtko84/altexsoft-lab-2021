using System.Threading.Tasks;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Enums;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class OrderService : IOrderController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger logger;
        private readonly ICache cache;
        private readonly IPriceController priceController;

        public OrderService(IUnitOfWork unitOfWork, ILogger logger, ICache cache, IPriceController priceController)
        {
            _unitOfWork = unitOfWork;
            this.logger = logger;
            this.cache = cache;
            this.priceController = priceController;
        }

        public Order AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress)
        {
            var order = new Order
            {
                CustomerId = buyerId
            };

            _unitOfWork.Products.Create(product);
            order.DeliveryAddress = deliveryAddress;
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();
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