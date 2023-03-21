using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class ShoesModelService
    {
        private readonly TheShoesShopDbContext _context;

        public ShoesModelService(TheShoesShopDbContext context) 
        { 
            _context = context;
        }

        public async Task<ShoesModelDTO?> GetShoesModelByID(int ShoesModelID)
        {
            var ShoesModel = await (
                             from sm in _context.shoesmodel
                             where sm.ShoesModelID == ShoesModelID
                             join b in _context.brand on sm.BrandID equals b.BrandID
                             select new ShoesModelDTO
                             {
                                 ShoesModelID = sm.ShoesModelID,
                                 ShoesModelName = sm.ShoesModelName,
                                 ShoesModelDescription = sm.ShoesModelDescription,
                                 ShoesModelStatus = sm.ShoesModelStatus,
                                 Brand = new BrandDTO { BrandID = b.BrandID, BrandName = b.BrandName },
                                 Images = (from i in _context.shoesmodelimage
                                           where i.ShoesModelID == sm.ShoesModelID
                                           select new ShoesModelImageDTO { ImageID = i.ImageID, ImageLink = i.ImageLink}).ToList(),
                                 Shoeses = (from s in _context.shoes
                                            where s.ShoesModelID == sm.ShoesModelID
                                            select new ShoesDTO
                                            {
                                                ShoesID = s.ShoesID,
                                                Color = s.Color,
                                                Quantity = s.Quantity,
                                                Size = s.Size,
                                                UnitPrice = s.UnitPrice,
                                                ShoesStatus = s.ShoesStatus,
                                            }).ToList(),
                             }).FirstOrDefaultAsync();

            return ShoesModel;
        }


    }
}
