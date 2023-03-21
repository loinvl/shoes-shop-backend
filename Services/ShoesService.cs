using Org.BouncyCastle.Bcpg.OpenPgp;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class ShoesService
    {
        private readonly TheShoesShopDbContext _context;

        public ShoesService(TheShoesShopDbContext context) 
        {
            _context = context;
        }

        //public async Task<shoesmodel> GetShoesList(int Page, int ItemPerPage)
        //{
        //    var ShoesList = await _context.shoesmodel.Select(
        //}
    }
}
