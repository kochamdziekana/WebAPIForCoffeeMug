using AutoMapper;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.MappingProfiles
{
    public class ProductManagementMappingProfile : Profile
    {
        public ProductManagementMappingProfile()
        {
            CreateMap<Product, ProductDto>() // for getting the products
                .ForMember(p => p.Name, c => c.MapFrom(s => s.Name))
                .ForMember(p => p.Number, c => c.MapFrom(s => s.Number))
                .ForMember(p => p.Quantity, c => c.MapFrom(s => s.Quantity))
                .ForMember(p => p.Description, c => c.MapFrom(s => s.Description))
                .ForMember(p => p.Price, c => c.MapFrom(s => s.Price));

            CreateMap<NewProductDto, Product>() // for adding the products
                .ForMember(p => p.Name, c => c.MapFrom(s => s.Name))
                .ForMember(p => p.Number, c => c.MapFrom(s => s.Number))
                .ForMember(p => p.Quantity, c => c.MapFrom(s => s.Quantity))
                .ForMember(p => p.Description, c => c.MapFrom(s => s.Description))
                .ForMember(p => p.Price, c => c.MapFrom(s => s.Price));

        }
    }
}
