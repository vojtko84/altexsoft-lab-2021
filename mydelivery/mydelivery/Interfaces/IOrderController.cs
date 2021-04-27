using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface IOrderController
    {
        void AddOrder(int buyerId, Product product, DeliveryAddress deliveryAddress);
    }
}