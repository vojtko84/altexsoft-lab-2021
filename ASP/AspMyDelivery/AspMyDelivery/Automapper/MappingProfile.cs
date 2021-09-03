using AspMyDelivery.API.DataTransferObjects;
using AutoMapper;
using DeliveryEF.Domain.Models;

namespace AspMyDelivery.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<Provider, ProviderDto>();
            CreateMap<ProviderForCreationDto, Provider>();
        }
    }
}