using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class BrandService
    {
        private readonly TheShoesShopDbContext _context;

        public BrandService(TheShoesShopDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<BrandDTO>> GetBrandList()
        {
            var BrandList = await (from b in _context.brand
                                   select new BrandDTO
                                   {
                                       BrandID = b.BrandID,
                                       BrandName = b.BrandName,
                                   }).ToListAsync();

            return BrandList;
        }
    }
}
