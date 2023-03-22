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
        }
    }
}
