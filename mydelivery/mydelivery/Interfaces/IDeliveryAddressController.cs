using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface IDeliveryAddressController
    {
        DeliveryAddress AddDeliveryAddress(string houseNumber, string streetName, string apartmentNumber, string cityName, string areaName, string postCode, int buyerId);
    }
}