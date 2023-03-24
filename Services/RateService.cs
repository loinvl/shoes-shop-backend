using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class RateService
    {
        private readonly TheShoesShopDbContext _context;
        private readonly PurchaseOrderService _PurchaseOrderService;

        public RateService(TheShoesShopDbContext context, PurchaseOrderService PurchaseOrderService) 
        {
            _context = context;
            _PurchaseOrderService = PurchaseOrderService;
        }

        // Get rate list of one shoes model by id
        public async Task<IEnumerable<RateDTO>> GetRateListOfShoesModel(int ShoesModelID)
        {
            var RateList = await 
                           (from r in _context.rate
                           join s in _context.shoes on r.ShoesID equals s.ShoesID
                           join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                           where sm.ShoesModelID == ShoesModelID
                           select new RateDTO
                           {
                               RateStar = r.RateStar,
                               Content = r.Content,
                               RateTime = r.RateTime,
                               ImageLink = r.ImageLink,
                               Customer = (from c in _context.customer
                                           where c.CustomerID == r.CustomerID
                                           select new CustomerDTO { 
                                               CustomerID = c.CustomerID,
                                               CustomerName = c.CustomerName
                                           }).FirstOrDefault(),
                               Shoes = (from s in _context.shoes
                                        where s.ShoesID == r.ShoesID
                                        select new ShoesDTO
                                        {
                                            ShoesID = s.ShoesID,
                                            Color = s.Color,
                                            Size = s.Size,
                                        }).FirstOrDefault(),
                           }).ToListAsync();

            return RateList;
        }

        public async Task<RateDTO?> AddRate(AddingRateDTO Rate, int CustomerID)
        {
            // Check purchase order of customer
            var PurchaseOrder = await _context.purchaseorder
                .SingleOrDefaultAsync(p => p.PurchaseOrderID == Rate.PurchaseOrderID 
                                        && p.CustomerID == CustomerID);
            if(PurchaseOrder == null )
            {
                return null;
            }

            // Check rate previous, one purchasse only have one rate
            var ExistingRate = await _context.rate.SingleOrDefaultAsync(r =>
                                        r.PurchaseOrderID == Rate.PurchaseOrderID
                                        && r.ShoesID == Rate.ShoesID);
            if(ExistingRate != null)
            {
                return null;
            }

            // Add essential info
            var RateEntity = new rate
            {
                PurchaseOrderID = Rate.PurchaseOrderID ?? 0,
                ShoesID = Rate.ShoesID ?? 0,
                CustomerID = CustomerID,
                Content = Rate.Content,
                RateStar = Rate.RateStar ?? 5,
                RateTime = DateTime.Now,
                ImageLink = Rate.ImageLink,
            };

            // Add rate
            var NewRateEntity = (await _context.rate.AddAsync(RateEntity)).Entity;
            await _context.SaveChangesAsync();

            //return
            var RateID = new RateID { PurchaseOrderID = NewRateEntity.PurchaseOrderID, ShoesID = NewRateEntity.ShoesID };
            var NewRate = await GetRateOfOneOrder( RateID, CustomerID);
            return NewRate;
        }

        public async Task<RateDTO?> GetRateOfOneOrder(RateID RateID, int CustomerID)
        {
            var Rate = await (from r in _context.rate
                            where r.PurchaseOrderID == RateID.PurchaseOrderID && r.ShoesID == RateID.ShoesID
                            && r.CustomerID == CustomerID
                            select new RateDTO
                            {
                                Content = r.Content,
                                RateStar = r.RateStar,
                                RateTime = r.RateTime,
                                ImageLink = r.ImageLink,
                                Customer = (from c in _context.customer
                                            where c.CustomerID == r.CustomerID
                                            select new CustomerDTO
                                            {
                                                CustomerID = c.CustomerID,
                                                CustomerName = c.CustomerName
                                            }).FirstOrDefault(),
                                Shoes = (from s in _context.shoes
                                        where s.ShoesID == r.ShoesID
                                        select new ShoesDTO
                                        {
                                            ShoesID = s.ShoesID,
                                            Color = s.Color,
                                            Size = s.Size
                                        }).FirstOrDefault(),
                            }).FirstOrDefaultAsync();

            return Rate;
        }
    }
}
