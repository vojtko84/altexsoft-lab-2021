namespace DeliveryEF.Domain.Models
{
    public class DeliveryRate : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}