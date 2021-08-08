using System;
using System.Collections.Generic;
using DeliveryEF.Domain.Enums;

namespace DeliveryEF.Domain.Models
{
    public class Order : BaseModel
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DeliveryAddressId { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderReceiptTime { get; set; }
        public DateTime CustomerTransferTime { get; set; }
        public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int DeliveryRateId { get; set; }
        public DeliveryRate DeliveryRate { get; set; }
        public OrderStatus OrederStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}