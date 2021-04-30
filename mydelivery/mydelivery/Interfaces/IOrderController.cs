using MyDelivery.Models;

namespace MyDelivery.Interfaces
{
    public interface IOrderController
    {
        void AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress);
    }
}