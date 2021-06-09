namespace MyDelivery.Models
{
    public class ExchangeRate
    {
        public string BaseCurrency { get; set; }
        public string Currency { get; set; }
        public decimal SaleRateNB { get; set; }
        public decimal PurchaseRateNB { get; set; }
        public decimal SaleRate { get; set; }
        public decimal PurchaseRate { get; set; }
    }
}