namespace Delivery.Models
{
    public class Customer : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}