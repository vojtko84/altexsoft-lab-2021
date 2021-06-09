using MyDelivery.Data;
using System.Threading.Tasks;

namespace MyDelivery.Interfaces
{
    public interface IPriceController
    {
        Task<decimal> RecalculatePriceInAnotherCurrencyAsync(Enums.CurrencyName currencyName, decimal price);
    }
}