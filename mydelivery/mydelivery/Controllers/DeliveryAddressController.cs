using Mydelivery.Data;
using Mydelivery.Models;

namespace Mydelivery.Controllers
{
    public class DeliveryAddressController
    {
        private readonly Context context;

        public DeliveryAddressController(Context context)
        {
            this.context = context;
        }

        public DeliveryAddress AddDeliveryAddress(string houseNumber, string streetName, string apartmentNumber, string cityName, string areaName, string postCode, int buyerId)
        {
            var deliveryAddress = new DeliveryAddress
            {
                HouseNumber = houseNumber,
                StreetName = streetName,
                ApartmentNumber = apartmentNumber,
                CityName = cityName,
                AreaName = areaName,
                PostCode = postCode,
                Id = context.DeliveryAddresses.Count + 1,
                BuyerId = buyerId
            };
            context.DeliveryAddresses.Add(deliveryAddress);
            context.Save();
            return deliveryAddress;
        }
    }
}