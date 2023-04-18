using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.Services
{
    public class PurchaseOrderService
    {
        private readonly TheShoesShopDbContext _context;
        private readonly CartDetailService _CartDetailService;

        public PurchaseOrderService(
            TheShoesShopDbContext context, 
            CartDetailService CartDetailService
        ) 
        { 
            _context = context;
            _CartDetailService = CartDetailService;
        }

        // Checkout
        public async Task<PurchaseOrderDTO?> Checkout(int CustomerID, CheckoutDTO Order)
        {
            // Add purchase order
            var OrderEntity = new purchaseorder
            {
                CustomerID = CustomerID,
                CustomerName = Order.CustomerName,
                Email = Order.Email,
                Address = Order.Address,
                Note = Order.Note,
                Phone = Order.Phone,
                OrderTime = DateTime.Now
            };
            var NewOrderEntity = (await _context.purchaseorder.AddAsync(OrderEntity)).Entity;
            await _context.SaveChangesAsync();

            // Add order detail entity
            var OrderDetails = Order.CheckoutDetails;
            foreach(CheckoutDetail OrderDetail in OrderDetails)
            {
                // Get shoes info to add
                var Shoes = await _context.shoes.SingleOrDefaultAsync(s => s.ShoesID == OrderDetail.ShoesID);

                if(Shoes == null || Shoes.Quantity < OrderDetail.Quantity)
                {
                    return null;
                }

                // Add to context
                var OrderDetailEntity = new orderdetail
                {
                    PurchaseOrderID = NewOrderEntity.PurchaseOrderID,
                    ShoesID = Shoes.ShoesID,
                    Quantity = OrderDetail.Quantity ?? 1,
                    UnitPrice = Shoes.UnitPrice
                };
                await _context.orderdetail.AddAsync(OrderDetailEntity);
                Shoes.Quantity = Shoes.Quantity - (OrderDetail.Quantity ?? 1);

                // Remove in cart if exist
                var CartDetail = new CartDetailDTO { CustomerID = CustomerID, ShoesID = Shoes.ShoesID };
                await _CartDetailService.RemoveShoes(CartDetail);
            }
            await _context.SaveChangesAsync();


            // Return new purchase order
            var NewOrder = await GetPurchaseOrderByID(NewOrderEntity.PurchaseOrderID, CustomerID);
            return NewOrder;
        }

        // Get one purchase order
        public async Task<PurchaseOrderDTO?> GetPurchaseOrderByID(int PurchaseOrderID, int? CustomerID)
        {
            var PurchaseOrder = await (from p in _context.purchaseorder
                                       where p.PurchaseOrderID == PurchaseOrderID
                                       where CustomerID == null || p.CustomerID == CustomerID
                                       select new PurchaseOrderDTO
                                       {
                                           PurchaseOrderID = p.PurchaseOrderID,
                                           Phone = p.Phone,
                                           Address = p.Address,
                                           Email = p.Email,
                                           CustomerName = p.CustomerName,
                                           OrderStatus = p.OrderStatus,
                                           Note = p.Note,
                                           OrderTime = p.OrderTime,
                                           Customer = null,
                                           OrderDetail = (from od in _context.orderdetail
                                                          where od.PurchaseOrderID == p.PurchaseOrderID
                                                          select new OrderDetailDTO
                                                          {
                                                              PurchaseOrderID = p.PurchaseOrderID,
                                                              Quantity = od.Quantity,
                                                              UnitPrice = od.UnitPrice,
                                                              Shoes = (from s in _context.shoes
                                                                       where s.ShoesID == od.ShoesID
                                                                       select new ShoesDTO
                                                                       {
                                                                           ShoesID = s.ShoesID,
                                                                           Color = s.Color,
                                                                           ShoesStatus = s.ShoesStatus,
                                                                           Size = s.Size
                                                                       }).FirstOrDefault(),
                                                              ShoesModel = (from s in _context.shoes
                                                                            where s.ShoesID == od.ShoesID
                                                                            join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                                                                            select new ShoesModelDTO
                                                                            {
                                                                                ShoesModelName = sm.ShoesModelName,
                                                                                Images = (from i in _context.shoesmodelimage
                                                                                          where i.ShoesModelID == sm.ShoesModelID
                                                                                          select new ShoesModelImageDTO
                                                                                          {
                                                                                              ImageLink = i.ImageLink
                                                                                          }).ToList(),
                                                                            }).FirstOrDefault(),
                                                          }).ToList(),
                                       }).FirstOrDefaultAsync();

            return PurchaseOrder;
        }

        // Get all purchase order of customer
        public async Task<IEnumerable<PurchaseOrderDTO>> GetAllPurchaseOrderOfCustomer(int CustomerID)
        {
            var PurchaseOrderList = await (from p in _context.purchaseorder
                                       where p.CustomerID == CustomerID
                                       orderby p.OrderTime descending
                                       select new PurchaseOrderDTO
                                       {
                                           PurchaseOrderID = p.PurchaseOrderID,
                                           Phone = p.Phone,
                                           Address = p.Address,
                                           Email = p.Email,
                                           CustomerName = p.CustomerName,
                                           OrderStatus = p.OrderStatus,
                                           Note = p.Note,
                                           OrderTime = p.OrderTime,
                                           Customer = null,
                                           OrderDetail = (from od in _context.orderdetail
                                                          where od.PurchaseOrderID == p.PurchaseOrderID
                                                          select new OrderDetailDTO
                                                          {
                                                              PurchaseOrderID = p.PurchaseOrderID,
                                                              Quantity = od.Quantity,
                                                              UnitPrice = od.UnitPrice,
                                                              Shoes = (from s in _context.shoes
                                                                       where s.ShoesID == od.ShoesID
                                                                       select new ShoesDTO
                                                                       {
                                                                           ShoesID = s.ShoesID,
                                                                           Color = s.Color,
                                                                           ShoesStatus = s.ShoesStatus,
                                                                           Size = s.Size
                                                                       }).FirstOrDefault(),
                                                              ShoesModel = (from s in _context.shoes
                                                                            where s.ShoesID == od.ShoesID
                                                                            join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                                                                            select new ShoesModelDTO
                                                                            {
                                                                                ShoesModelName = sm.ShoesModelName,
                                                                                Images = (from i in _context.shoesmodelimage
                                                                                          where i.ShoesModelID == sm.ShoesModelID
                                                                                          select new ShoesModelImageDTO
                                                                                          {
                                                                                              ImageLink = i.ImageLink
                                                                                          }).ToList(),
                                                                            }).FirstOrDefault(),
                                                          }).ToList(),
                                       }).ToListAsync();

            return PurchaseOrderList;
        }

        // customer cancel purchase
        public async Task<PurchaseOrderDTO?> CancelPurchase(int PurchaseOrderID, int CustomerID)
        {
            var CancelPurchase = await _context.purchaseorder.SingleOrDefaultAsync(p =>
                p.PurchaseOrderID == PurchaseOrderID
                && p.CustomerID == CustomerID
                && p.OrderStatus < 2);

            if (CancelPurchase == null)
            {
                return null;
            }

            // update
            CancelPurchase.OrderStatus = 5;
            await _context.SaveChangesAsync();

            // get purhcase order
            var NewPurchase = await GetPurchaseOrderByID(PurchaseOrderID, CustomerID);
            return NewPurchase;
        }

        // admin update purchase status
        public async Task<PurchaseOrderDTO?> UpdatePurchaseStatus(int PurchaseOrderID, int Status)
        {
            var Purchase = await _context.purchaseorder.SingleOrDefaultAsync(p =>
                p.PurchaseOrderID == PurchaseOrderID);

            if(Purchase == null)
            {
                return null;
            }

            // update
            Purchase.OrderStatus = Status;
            await _context.SaveChangesAsync();

            // get purhcase order
            var NewPurchase = await GetPurchaseOrderByID(PurchaseOrderID, null);
            return NewPurchase;
        }

        // Get all purchase order  for admin
        public async Task<IEnumerable<PurchaseOrderDTO>> GetAllPurchaseOrder()
        {
            var PurchaseOrderList = await (from p in _context.purchaseorder
                                           orderby p.OrderTime descending
                                           select new PurchaseOrderDTO
                                           {
                                               PurchaseOrderID = p.PurchaseOrderID,
                                               Phone = p.Phone,
                                               Address = p.Address,
                                               Email = p.Email,
                                               CustomerName = p.CustomerName,
                                               OrderStatus = p.OrderStatus,
                                               Note = p.Note,
                                               OrderTime = p.OrderTime,
                                               Customer = null,
                                               OrderDetail = (from od in _context.orderdetail
                                                              where od.PurchaseOrderID == p.PurchaseOrderID
                                                              select new OrderDetailDTO
                                                              {
                                                                  PurchaseOrderID = p.PurchaseOrderID,
                                                                  Quantity = od.Quantity,
                                                                  UnitPrice = od.UnitPrice,
                                                                  Shoes = (from s in _context.shoes
                                                                           where s.ShoesID == od.ShoesID
                                                                           select new ShoesDTO
                                                                           {
                                                                               ShoesID = s.ShoesID,
                                                                               Color = s.Color,
                                                                               ShoesStatus = s.ShoesStatus,
                                                                               Size = s.Size
                                                                           }).FirstOrDefault(),
                                                                  ShoesModel = (from s in _context.shoes
                                                                                where s.ShoesID == od.ShoesID
                                                                                join sm in _context.shoesmodel on s.ShoesModelID equals sm.ShoesModelID
                                                                                select new ShoesModelDTO
                                                                                {
                                                                                    ShoesModelName = sm.ShoesModelName,
                                                                                    Images = (from i in _context.shoesmodelimage
                                                                                              where i.ShoesModelID == sm.ShoesModelID
                                                                                              select new ShoesModelImageDTO
                                                                                              {
                                                                                                  ImageLink = i.ImageLink
                                                                                              }).ToList(),
                                                                                }).FirstOrDefault(),
                                                              }).ToList(),
                                           }).ToListAsync();

            return PurchaseOrderList;
        }
    }
}
