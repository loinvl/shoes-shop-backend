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
            //CreateMap<List<customer>, List<CustomerDTO>>();
        }
    }
}
