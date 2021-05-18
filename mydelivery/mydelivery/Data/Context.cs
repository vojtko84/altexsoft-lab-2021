using MyDelivery.Interfaces;
using MyDelivery.Models;
using System.Collections.Generic;

namespace MyDelivery.Data
{
    public class Context : IContext
    {
        private readonly IDataManager dataManager;
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

        public Context(IDataManager dataManager)
        {
            this.dataManager = dataManager;
            Products = dataManager.Load<Product>(productFileName);
            Buyers = dataManager.Load<Buyer>(buyerFileName);
            Sellers = dataManager.Load<Seller>(sellerFileName);
            Categories = dataManager.Load<Category>(categoryFileName);
            DeliveryAddresses = dataManager.Load<DeliveryAddress>(deliveryAddresFileName);
            Orders = dataManager.Load<Order>(orderFileName);
        }

        public void Save()
        {
            dataManager.Save(Products, productFileName);
            dataManager.Save(Buyers, buyerFileName);
            dataManager.Save(Sellers, sellerFileName);
            dataManager.Save(Categories, categoryFileName);
            dataManager.Save(DeliveryAddresses, deliveryAddresFileName);
            dataManager.Save(Orders, orderFileName);
        }
    }
}