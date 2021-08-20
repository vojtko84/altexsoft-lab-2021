using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Interfaces;

namespace MyDelivery.Controllers
{
    public class DeliveryAddressController : IDeliveryAddressController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger logger;
        private readonly ICache cache;

        public DeliveryAddressController(IUnitOfWork unitOfWork, ILogger logger, ICache cache)
        {
            _unitOfWork = unitOfWork;
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
            };
            _unitOfWork.DeliveryAddresses.Create(deliveryAddress);
            _unitOfWork.Save();
            cache.Add<DeliveryAddress>(deliveryAddress.Id, deliveryAddress);
            logger.SaveIntoFile($"Added delivery address ID: {deliveryAddress.Id}");
            return deliveryAddress;
        }

        public DeliveryAddress AddDeliveryAddress(string address, int buyerId)
        {
            var deliveryAddress = new DeliveryAddress();
            string[] separators = { ".", ",", " ", };
            var parsedAddress = address.Trim().Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            deliveryAddress.StreetName = parsedAddress[1];
            deliveryAddress.HouseNumber = parsedAddress[3];
            if (parsedAddress.Length < 4)
            {
                deliveryAddress.ApartmentNumber = parsedAddress[5];
            }
            _unitOfWork.DeliveryAddresses.Create(deliveryAddress);
            _unitOfWork.Save();
            cache.Add<DeliveryAddress>(deliveryAddress.Id, deliveryAddress);
            logger.SaveIntoFile($"Added delivery address ID: {deliveryAddress.Id}");
            return deliveryAddress;
        }
    }
}