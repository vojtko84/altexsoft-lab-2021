using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class DeliveryAddressController : IDeliveryAddressController
    {
        private readonly IContext context;
        private readonly ILogger logger;
        private readonly ICache cache;

        public DeliveryAddressController(IContext context, ILogger logger, ICache cache)
        {
            this.context = context;
            this.logger = logger;
            this.cache = cache;
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
                Id = context.DeliveryAddresses.Max(s => s.Id) + 1,
                BuyerId = buyerId
            };
            context.DeliveryAddresses.Add(deliveryAddress);
            context.Save();
            cache.Add<DeliveryAddress>(deliveryAddress.Id, deliveryAddress);
            logger.SaveIntoFile($"Added delivery address ID: {deliveryAddress.Id}");
            return deliveryAddress;
        }

        public DeliveryAddress AddDeliveryAddress(string address, int buyerId)
        {
            var deliveryAddress = new DeliveryAddress();
            deliveryAddress.BuyerId = buyerId;
            deliveryAddress.Id = context.DeliveryAddresses.Max(s => s.Id) + 1;
            string[] separators = { ".", ",", " ", };
            var parsedAddress = address.Trim().Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            deliveryAddress.StreetName = parsedAddress[1];
            deliveryAddress.HouseNumber = parsedAddress[3];
            if (parsedAddress.Length < 4)
            {
                deliveryAddress.ApartmentNumber = parsedAddress[5];
            }
            context.DeliveryAddresses.Add(deliveryAddress);
            context.Save();
            cache.Add<DeliveryAddress>(deliveryAddress.Id, deliveryAddress);
            logger.SaveIntoFile($"Added delivery address ID: {deliveryAddress.Id}");
            return deliveryAddress;
        }
    }
}