using Infrastructure.DTOs;
using Core.Models;
using AutoMapper;
using API.DTOs;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductReturnDTO>().
                ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name)).
                ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name)).
                ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}
