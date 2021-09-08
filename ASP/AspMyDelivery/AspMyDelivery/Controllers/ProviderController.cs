using System.Collections.Generic;
using AspMyDelivery.API.ViewModels;
using AspMyDelivery.BLL.Interfaces;
using AutoMapper;
using DeliveryEF.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMyDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProviderController(IProviderService providerService, IMapper mapper)
        {
            _providerService = providerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProviderViewModel> Get()
        {
            var providers = _providerService.GetProviders();
            var providersViewModel = _mapper.Map<IEnumerable<ProviderViewModel>>(providers);

            return providersViewModel;
        }

        [HttpGet("{id}")]
        public ProviderViewModel Get(int id)
        {
            var provider = _providerService.GetProvider(id);
            var providerViewModel = _mapper.Map<ProviderViewModel>(provider);

            return providerViewModel;
        }

        [HttpPost]
        public void Post([FromBody] CreateProviderViewModel provider)
        {
            var providerEntity = _mapper.Map<Provider>(provider);
            _providerService.AddProvider(providerEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateProviderViewModel provider)
        {
            var providerEntity = _mapper.Map<Provider>(provider);
            providerEntity.Id = id;
            _providerService.UpdateProvider(providerEntity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _providerService.DeleteProvider(id);
        }
    }
}