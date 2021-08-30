using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyDelivery.Enums;
using MyDelivery.Interfaces;
using MyDelivery.Models;

namespace MyDelivery.Controllers
{
    public class PriceService : IPriceService
    {
        public async Task<decimal> GetPriceForCurrency(CurrencyNames currencyName, decimal price)
        {
            var date = DateTime.Today.AddDays(-1).ToString("dd.MM.yyyy");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://api.privatbank.ua/p24api/exchange_rates?json&date={date}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var exchangeRates = JsonSerializer.Deserialize<ExchangeRatesResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
            var currentCurrency = exchangeRates.ExchangeRates.FirstOrDefault(x => x.Currency == currencyName.ToString());

            return price / currentCurrency.SaleRate;
        }
    }
}