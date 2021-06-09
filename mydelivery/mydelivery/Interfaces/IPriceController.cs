using MyDelivery.Enums;
using System.Threading.Tasks;

namespace MyDelivery.Interfaces
{
    public interface IPriceController
    {
        Task<decimal> GetPriceForCurrency(CurrencyNames currencyName, decimal price);
    }
}