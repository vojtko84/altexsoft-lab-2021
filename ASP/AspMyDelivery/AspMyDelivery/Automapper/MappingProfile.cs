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
            CreateMap<ProductForCreateViewModel, Product>();
            CreateMap<ProductForEditViewModel, Product>().ReverseMap();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryForCreateViewModel, Category>();
            CreateMap<Provider, ProviderViewModel>();
            CreateMap<ProviderForCreateViewModel, Provider>();
        }
    }
}