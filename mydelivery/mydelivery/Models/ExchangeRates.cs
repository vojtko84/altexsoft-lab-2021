using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyDelivery.Models
{
    public class ExchangeRates
    {
        public IEnumerable<ExchangeRate> ExchangeRate { get; set; }
    }
}