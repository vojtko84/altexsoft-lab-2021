using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Delivery.Models
{
    [Table("Categories")]
    public class Category : BaseModel
    {
        public string Name { get; set; }

        [Write(false)]
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}