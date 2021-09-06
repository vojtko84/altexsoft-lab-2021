using System;
using System.Collections.Generic;
using DeliveryEF.Domain.Enums;
using DeliveryEF.Domain.Models;

namespace AspMyDelivery.API.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryAddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderReceiptTime { get; set; }
        public DateTime CustomerTransferTime { get; set; }
        public int DeliveryManId { get; set; }
        public int DeliveryRateId { get; set; }
        public OrderStatus OrederStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}