using System.Threading.Tasks;
using MyDelivery.Enums;

namespace MyDelivery.Interfaces
{
    public interface IPriceService
    {
        Task<decimal> GetPriceForCurrency(CurrencyNames currencyName, decimal price);
    }
}