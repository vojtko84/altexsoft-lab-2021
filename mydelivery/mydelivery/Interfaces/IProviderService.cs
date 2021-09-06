using System.Collections.Generic;
using DeliveryEF.Domain.Models;

namespace AspMyDelivery.BLL.Interfaces
{
    public interface IProviderService
    {
        IList<Provider> GetProviders();

        void AddProvider(Provider provider);

        Provider GetProvider(int id);

        void UpdateProvider(Provider provider);

        void DeleteProvider(int id);
    }
}