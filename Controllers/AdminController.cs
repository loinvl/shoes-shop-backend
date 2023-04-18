using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;

        public AdminController(TheShoesShopServices TheShoesShopServices) 
        {
            _TheShoesShopServices = TheShoesShopServices;
        }

        [HttpPatch("purchase/{purchaseOrderID}/status/update/{orderStatus}")]
        [Authorize]
        public async Task<IActionResult> UpdatePurchaseStatus(int purchaseOrderID, int orderStatus)
        {
            try
            {
                // get user
                var User = new User(HttpContext.User);

                // is not admin
                if (User != null && User.UserRole != 1)
                {
                    return StatusCode(403, new Response
                    {
                        Success = false,
                        Message = "You are not permission to do that",
                        ErrorCode = 1
                    });
                }

                var UpdatedPurchase = await _TheShoesShopServices._PurchaseOrderService.UpdatePurchaseStatus(purchaseOrderID, orderStatus);

                // check 
                if (UpdatedPurchase == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = $"Purchase with id = {purchaseOrderID} is not exist",
                        ErrorCode = 2
                    });
                }


                return Ok(new Response
                {
                    Success = true,
                    Message = $"Update successfully",
                    Data = new { UpdatedPurchase }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = $"Server error",
                    ErrorCode = 500
                });
            }
        }
    }
}
