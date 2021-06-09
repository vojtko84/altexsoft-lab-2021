﻿using MyDelivery.Data;
using MyDelivery.Interfaces;
using MyDelivery.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyDelivery.Controllers
{
    public class PriceController : IPriceController
    {
        public async Task<decimal> RecalculatePriceInAnotherCurrencyAsync(Enums.CurrencyName currencyName, decimal price)
        {
            return price / await GetCurrencySaleRateAsync(currencyName);
        }

        private async Task<decimal> GetCurrencySaleRateAsync(Enums.CurrencyName currencyName)
        {
            var date = DateTime.Today.AddDays(-1).ToString("dd.MM.yyyy");
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://api.privatbank.ua/p24api/exchange_rates?json&date={date}");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var exchangeRates = JsonSerializer.Deserialize<ExchangeRates>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
            var currentCurrency = exchangeRates.ExchangeRate.FirstOrDefault(x => x.Currency == currencyName.ToString());

            return currentCurrency.SaleRate;
        }
    }
}