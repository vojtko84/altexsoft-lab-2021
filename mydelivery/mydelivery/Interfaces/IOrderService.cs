using System.Threading.Tasks;
using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface IOrderService
    {
        Order AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress);

        Task<decimal> GetRecalculatePriceInUSD(Order order);
    }
}