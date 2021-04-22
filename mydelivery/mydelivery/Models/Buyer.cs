namespace Mydelivery.Models
{
    public class Buyer : BaseModel, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}