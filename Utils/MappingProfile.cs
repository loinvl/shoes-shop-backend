using AutoMapper;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<customer, CustomerDTO>();
            CreateMap<CustomerDTO, customer>();
            CreateMap<shoes, ShoesDTO>();
            CreateMap<cartdetail, CartDetailDTO>();
            CreateMap<CartDetailDTO, cartdetail>();
            CreateMap<PurchaseOrderDTO, purchaseorder>()
                .ForMember(p => p.CustomerID, opt => opt.MapFrom(pDTO => pDTO.Customer!.CustomerID))
                .ForMember(p => p.orderdetail, opt => opt.Ignore())
                .ForMember(p => p.Customer, opt => opt.Ignore());
            CreateMap<OrderDetailDTO, orderdetail>()
                .ForMember(od => od.ShoesID, opt => opt.MapFrom(odDTO => odDTO.Shoes!.ShoesID))
                .ForMember(od => od.PurchaseOrder, opt => opt.Ignore())
                .ForMember(od => od.Shoes, opt => opt.Ignore());

        }
    }
}
