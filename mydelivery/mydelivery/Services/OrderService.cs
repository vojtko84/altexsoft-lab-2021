using System.Threading.Tasks;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Enums;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyLogger logger;
        private readonly ICache cache;
        private readonly IPriceService priceController;

        public OrderService(IUnitOfWork unitOfWork, IMyLogger logger, ICache cache, IPriceService priceController)
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