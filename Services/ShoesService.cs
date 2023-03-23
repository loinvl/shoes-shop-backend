using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class ShoesService
    {
        private readonly TheShoesShopDbContext _context;
        private readonly IMapper _mapper;

        public ShoesService(TheShoesShopDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShoesDTO> GetShoesByID(int? ShoesID)
        {
            var ShoesEntity = await _context.shoes.SingleOrDefaultAsync(s => s.ShoesID ==  ShoesID);
            var Shoes = _mapper.Map<ShoesDTO>(ShoesEntity);

            return Shoes;
        }

        public async Task<ShoesDTO> GetStockingShoesByID(int ShoesID, int Quantity)
        {
            var ShoesEntity = await _context.shoes.SingleOrDefaultAsync(s => s.ShoesID == ShoesID && s.Quantity >= Quantity);
            var Shoes = _mapper.Map<ShoesDTO>(ShoesEntity);

            return Shoes;
        }

        // Update shoes quantity in warehouse
        public async Task<bool> UpdateShoesQuantity(int ShoesID, int Quantity)
        {
            var Shoes = await _context.shoes.SingleOrDefaultAsync(s => s.ShoesID == ShoesID);
            if(Shoes == null) return false;

            Shoes.Quantity = Quantity;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
