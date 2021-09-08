using System.Collections.Generic;
using System.Linq;
using AspMyDelivery.BLL.Interfaces;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;
using MyDelivery.Interfaces;

namespace AspMyDelivery.BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyLogger _logger;

        public ProviderService(IUnitOfWork unitOfWork, IMyLogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void AddProvider(Provider provider)
        {
            _unitOfWork.Providers.Create(provider);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Added provider {provider.Name}");
        }

        public void DeleteProvider(int id)
        {
            _unitOfWork.Providers.DeleteById(id);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Deleted provider ID: {id}");
        }

        public Provider GetProvider(int id)
        {
            return _unitOfWork.Providers.GetById(id);
        }

        public IList<Provider> GetProviders()
        {
            return _unitOfWork.Providers.GetAll().ToList();
        }

        public void UpdateProvider(Provider provider)
        {
            var providerToUpdate = GetProvider(provider.Id);
            providerToUpdate.Name = provider.Name;

            _unitOfWork.Providers.Update(providerToUpdate);
            _unitOfWork.Save();
            _logger.SaveIntoFile($"Update provider ID: {provider.Id}");
        }
    }
}