namespace DeliveryEF.Domain.Models
{
    public class DeliveryAddress : BaseModel
    {
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string ApartmentNumber { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public string PostCode { get; set; }
    }
}