using System.Collections.Generic;

namespace DeliveryEF.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public List<Order> Orders { get; set; }
    }
}