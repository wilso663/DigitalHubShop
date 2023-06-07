using Infrastructure.DTOs;
using Core.Models;
using AutoMapper;
using API.DTOs;
using Core.Models.Identities;
using Core.Models.OrderAggregate;

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
            CreateMap<Core.Models.Identities.Address, AddressDTO>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>();
            CreateMap<BasketItemDTO, BasketItem>();
            CreateMap<AddressDTO, Core.Models.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
