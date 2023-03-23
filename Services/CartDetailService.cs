using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class CartDetailService
    {
        private readonly TheShoesShopDbContext _context;
        private readonly IMapper _mapper;

        public CartDetailService(TheShoesShopDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all shoeses in cart of one customer
        public async Task<IEnumerable<CartDetailOfCustomerDTO>> GetCartDetailListOfCustomer(int CustomerID)
        {
            var CartDetailList = await (from cd in _context.cartdetail
                                        where cd.CustomerID == CustomerID
                                        join s in _context.shoes on cd.ShoesID equals s.ShoesID
                                        join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                                        select new CartDetailOfCustomerDTO
                                        {
                                            ShoesModel = new ShoesModelDTO
                                            {
                                                ShoesModelID = sm.ShoesModelID,
                                                ShoesModelName = sm.ShoesModelName,
                                                ShoesModelStatus = sm.ShoesModelStatus,
                                                Brand = (from b in _context.brand
                                                         where b.BrandID == sm.BrandID
                                                         select new BrandDTO { 
                                                             BrandID = b.BrandID, 
                                                             BrandName = b.BrandName
                                                         }).FirstOrDefault(),
                                                Images = (from i in _context.shoesmodelimage
                                                          where i.ShoesModelID == sm.ShoesModelID
                                                          select new ShoesModelImageDTO
                                                          {
                                                              ImageID = i.ShoesModelID,
                                                              ImageLink = i.ImageLink
                                                          }).ToList(),
                                            },
                                            Shoes = new ShoesDTO
                                            {
                                                ShoesID = s.ShoesID,
                                                Color = s.Color,
                                                Quantity = s.Quantity,
                                                ShoesStatus = s.ShoesStatus,
                                                Size = s.Size,
                                                UnitPrice = s.UnitPrice
                                            },
                                            Quantity = cd.Quantity
                                        }).ToListAsync();

            return CartDetailList;
        }


        // Get one shoes in cart of one customer
        public async Task<CartDetailOfCustomerDTO?> GetOneCartDetailOfCustomer(int CustomerID, int ShoesID)
        {
            var OneCartDetail = await    (from cd in _context.cartdetail
                                        where cd.CustomerID == CustomerID && cd.ShoesID == ShoesID
                                        join s in _context.shoes on cd.ShoesID equals s.ShoesID
                                        join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                                        select new CartDetailOfCustomerDTO
                                        {
                                            ShoesModel = new ShoesModelDTO
                                            {
                                                ShoesModelID = sm.ShoesModelID,
                                                ShoesModelName = sm.ShoesModelName,
                                                ShoesModelStatus = sm.ShoesModelStatus,
                                                Brand = (from b in _context.brand
                                                         where b.BrandID == sm.BrandID
                                                         select new BrandDTO
                                                         {
                                                             BrandID = b.BrandID,
                                                             BrandName = b.BrandName
                                                         }).FirstOrDefault(),
                                                Images = (from i in _context.shoesmodelimage
                                                          where i.ShoesModelID == sm.ShoesModelID
                                                          select new ShoesModelImageDTO
                                                          {
                                                              ImageID = i.ShoesModelID,
                                                              ImageLink = i.ImageLink
                                                          }).ToList(),
                                            },
                                            Shoes = new ShoesDTO
                                            {
                                                ShoesID = s.ShoesID,
                                                Color = s.Color,
                                                Quantity = s.Quantity,
                                                ShoesStatus = s.ShoesStatus,
                                                Size = s.Size,
                                                UnitPrice = s.UnitPrice
                                            },
                                            Quantity = cd.Quantity
                                        }).FirstOrDefaultAsync();

            return OneCartDetail;
        }

        // Add shoes in cart of one customer
        public async Task<CartDetailDTO> AddShoes(CartDetailDTO CartDetail)
        {
            // Existing cart detail, add quantity not add cart detail
            var ExistingCartDetail = await _context.cartdetail
                .SingleOrDefaultAsync(cd => cd.CustomerID == CartDetail.CustomerID && cd.ShoesID == CartDetail.ShoesID);
            if(ExistingCartDetail != null) 
            { 
                var NewQuantity = ExistingCartDetail.Quantity + CartDetail.Quantity;
                ExistingCartDetail.Quantity = NewQuantity ?? 1;
                _context.cartdetail.Update(ExistingCartDetail);
                await _context.SaveChangesAsync();

                var NewCartDetail = _mapper.Map<CartDetailDTO>(ExistingCartDetail);
                return NewCartDetail;
            }

            // Add new cart detail
            var CartDetailEntity = _mapper.Map<cartdetail>(CartDetail);
            var NewCartDetailEntity = (await _context.cartdetail.AddAsync(CartDetailEntity)).Entity;
            await _context.SaveChangesAsync();
            var NewCartDettail = _mapper.Map<CartDetailDTO>(NewCartDetailEntity);

            return NewCartDettail;
        }

        // Remove one shoes in cart of one customer
        public async Task<bool> RemoveShoes(CartDetailDTO CartDetail)
        {
            // Check shoes id in cart detail
            var CartDetailEntity = await _context.cartdetail
                .SingleOrDefaultAsync(cd => cd.CustomerID == CartDetail.CustomerID && cd.ShoesID == CartDetail.ShoesID);
            if (CartDetailEntity == null)
            {
                return false;
            }

            // Remove if it exist
            _context.cartdetail.Remove(CartDetailEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Update shoes amount of one shoes in cart of one customer
        public async Task<CartDetailDTO?> UpdateShoesAmount(CartDetailDTO CartDetail)
        {
            // Check one cart detail in cart detail
            var CartDetailEntity = await _context.cartdetail
                .SingleOrDefaultAsync(cd => cd.CustomerID == CartDetail.CustomerID && cd.ShoesID == CartDetail.ShoesID);

            // Not exist
            if (CartDetailEntity == null)
            {
                return null;
            }

            // Exist, update shoes amount
            CartDetailEntity.Quantity = CartDetail.Quantity ?? 1;
            await _context.SaveChangesAsync();

            // Return
            var NewCartDetail = _mapper.Map<CartDetailDTO>(CartDetailEntity);
            return NewCartDetail;
        }
    }
}
