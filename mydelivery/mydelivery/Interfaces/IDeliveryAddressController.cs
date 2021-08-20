using DeliveryEF.Domain.Models;

namespace MyDelivery.Interfaces
{
    public interface IDeliveryAddressController
    {
        DeliveryAddress AddDeliveryAddress(string houseNumber, string streetName, string apartmentNumber, string cityName, string areaName, string postCode, int buyerId);

        DeliveryAddress AddDeliveryAddress(string address, int buyerId);
    }
}