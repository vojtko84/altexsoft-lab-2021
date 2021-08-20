using System.Threading.Tasks;
using MyDelivery.Enums;

namespace MyDelivery.Interfaces
{
    public interface IPriceController
    {
        Task<decimal> GetPriceForCurrency(CurrencyNames currencyName, decimal price);
    }
}