using System.Text.Json.Serialization;

namespace MyDelivery.Models
{
    public class ExchangeRate
    {
        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("saleRateNB")]
        public decimal SaleRateNB { get; set; }

        [JsonPropertyName("purchaseRateNB")]
        public decimal PurchaseRateNB { get; set; }

        [JsonPropertyName("saleRate")]
        public decimal SaleRate { get; set; }

        [JsonPropertyName("purchaseRate")]
        public decimal PurchaseRate { get; set; }
    }
}