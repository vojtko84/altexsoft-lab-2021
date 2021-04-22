﻿using System.Collections.Generic;

namespace Mydelivery.Models
{
    public class Order : BaseModel
    {
        public int BuyerId { get; set; }
        public IList<Product> Products { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}