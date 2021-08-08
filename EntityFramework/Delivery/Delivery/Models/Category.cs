using System.Collections.Generic;

namespace Delivery.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}