using MyDelivery.Models;
using System.Threading.Tasks;

namespace MyDelivery.Interfaces
{
    public interface IOrderController
    {
        Order AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress);

        public Task<decimal> GetRecalculatePriceInUSD(Order order);
    }
}