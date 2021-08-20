using System;
using System.Collections.Generic;

namespace Delivery.Models
{
    public class Order : BaseModel
    {
        public int CustomerId { get; set; }
        public int DeliveryAddressId { get; set; }
        public decimal FullPrice { get; set; }
        public DateTime OrderReceiptTime { get; set; }
        public DateTime CustomerTransferTime { get; set; }
        public int DeliveryManId { get; set; }
        public int DeliveryRateId { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}