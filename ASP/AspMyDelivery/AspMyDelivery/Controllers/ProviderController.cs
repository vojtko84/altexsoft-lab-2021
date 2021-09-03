using System.Collections.Generic;
using AspMyDelivery.API.DataTransferObjects;
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
        public IEnumerable<ProviderDto> Get()
        {
            var providers = _providerService.GetProviders();
            var providersDto = _mapper.Map<IEnumerable<ProviderDto>>(providers);

            return providersDto;
        }

        [HttpGet("{id}")]
        public ProviderDto Get(int id)
        {
            var provider = _providerService.GetProvider(id);
            var providerDto = _mapper.Map<ProviderDto>(provider);

            return providerDto;
        }

        [HttpPost]
        public void Post([FromBody] ProviderForCreationDto provider)
        {
            var providerEntity = _mapper.Map<Provider>(provider);
            _providerService.AddProvider(providerEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProviderForCreationDto provider)
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