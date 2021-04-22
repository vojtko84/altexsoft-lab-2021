using Mydelivery.Models;
using System.Collections.Generic;

namespace Mydelivery.Data
{
    public class Context
    {
        public IList<Product> Products { get; set; }
        public IList<Buyer> Buyers { get; set; }
        public IList<Seller> Sellers { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<DeliveryAddress> DeliveryAddresses { get; set; }
        public IList<Order> Orders { get; set; }

        private readonly string productFileName = "products.json";
        private readonly string buyerFileName = "buyer.json";
        private readonly string sellerFileName = "seller.json";
        private readonly string categoryFileName = "category.json";
        private readonly string deliveryAddresFileName = "delivery.json";
        private readonly string orderFileName = "order.json";

        public Context()
        {
            Products = JsonManager.Load<Product>(productFileName);
            Buyers = JsonManager.Load<Buyer>(buyerFileName);
            Sellers = JsonManager.Load<Seller>(sellerFileName);
            Categories = JsonManager.Load<Category>(categoryFileName);
            DeliveryAddresses = JsonManager.Load<DeliveryAddress>(deliveryAddresFileName);
            Orders = JsonManager.Load<Order>(orderFileName);
        }

        public void Save()
        {
            JsonManager.Save(Products, productFileName);
            JsonManager.Save(Buyers, buyerFileName);
            JsonManager.Save(Sellers, sellerFileName);
            JsonManager.Save(Categories, categoryFileName);
            JsonManager.Save(DeliveryAddresses, deliveryAddresFileName);
            JsonManager.Save(Orders, orderFileName);
        }
    }
}