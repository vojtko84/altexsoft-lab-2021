using AspMyDelivery.API.ViewModels;
using AutoMapper;
using DeliveryEF.Domain.Models;

namespace AspMyDelivery.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductForCreationViewModel, Product>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryForCreationViewModel, Category>();
            CreateMap<Provider, ProviderViewModel>();
            CreateMap<ProviderForCreationViewModel, Provider>();
        }
    }
}