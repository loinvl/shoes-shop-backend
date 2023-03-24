using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class RateService
    {
        private readonly TheShoesShopDbContext _context;

        public RateService(TheShoesShopDbContext context) 
        {
            _context = context;
        }

        // Get rate list of one shoes model by id
        public async Task<IEnumerable<RateDTO>> GetRateListOfShoesModel(int ShoesModelID)
        {
            var RateList = await 
                           (from r in _context.rate
                           where r.ShoesModelID == ShoesModelID
                           select new RateDTO
                           {
                               RateID = r.RateID,
                               RateStar = r.RateStar,
                               Content = r.Content,
                               RateTime = r.RateTime,
                               Customer = (from c in _context.customer
                                           where c.CustomerID == r.CustomerID
                                           select new CustomerDTO { 
                                               CustomerID = c.CustomerID,
                                               CustomerName = c.CustomerName
                                           }).FirstOrDefault(),
                           }).ToListAsync();

            return RateList;
        }
    }
}
