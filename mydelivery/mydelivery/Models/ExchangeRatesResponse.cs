using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyDelivery.Models
{
    public class ExchangeRatesResponse
    {
        [JsonPropertyName("exchangeRate")]
        public IEnumerable<ExchangeRate> ExchangeRates { get; set; }
    }
}