﻿using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Linq;

namespace MyDelivery.Controllers
{
    public class DeliveryAddressController : IDeliveryAddressController
    {
        private readonly IContext context;

        public DeliveryAddressController(IContext context)
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
                Id = context.DeliveryAddresses.Max(s => s.Id) + 1,
                BuyerId = buyerId
            };
            context.DeliveryAddresses.Add(deliveryAddress);
            context.Save();
            return deliveryAddress;
        }
    }
}