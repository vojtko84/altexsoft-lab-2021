namespace MyDelivery.Models
{
    public class DeliveryAddress : BaseModel
    {
        public int BuyerId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public string PostCode { get; set; }
    }
}