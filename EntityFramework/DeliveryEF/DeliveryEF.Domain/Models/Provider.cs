using System.Collections.Generic;

namespace DeliveryEF.Domain.Models
{
    public class Provider : BaseModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}