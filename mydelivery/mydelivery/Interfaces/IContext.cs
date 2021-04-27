using System.Collections.Generic;
using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface IContext
    {
        public IList<Product> Products { get; set; }
        public IList<Buyer> Buyers { get; set; }
        public IList<Seller> Sellers { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<DeliveryAddress> DeliveryAddresses { get; set; }
        public IList<Order> Orders { get; set; }

        void Save();
    }
}