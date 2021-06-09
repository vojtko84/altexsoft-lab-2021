using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyDelivery.Models
{
    public class ExchangeRates
    {
        [JsonPropertyName("exchangeRate")]
        public List<ExchangeRate> ExcangeRates { get; set; }
    }
}