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
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<EditProductViewModel, Product>().ReverseMap();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Provider, ProviderViewModel>();
            CreateMap<CreateProviderViewModel, Provider>();
        }
    }
}