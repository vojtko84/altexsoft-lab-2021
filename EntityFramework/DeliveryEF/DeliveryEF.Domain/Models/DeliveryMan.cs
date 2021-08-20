using System.Collections.Generic;

namespace DeliveryEF.Domain.Models
{
    public class DeliveryMan : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}