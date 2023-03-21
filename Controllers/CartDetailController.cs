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
    public class CartDetailController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;

        public CartDetailController( TheShoesShopServices TheShoesShopServices) 
        { 
            _TheShoesShopServices = TheShoesShopServices;
        }

        // Add shoes instance into cart detail
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddShoes(CartDetailDTO CartDetail)
        {
            try
            {
                // Check shoes in database
                var Shoes = _TheShoesShopServices._ShoesService.GetShoesByID(CartDetail.ShoesID);
                if(Shoes == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Shoes is not exist"
                    });
                }

                // Add detail to cart
                var User = new User(HttpContext.User);
                CartDetail.CustomerID = User.CustomerID;
                var NewCartDetail = await _TheShoesShopServices._CartDetailService.AddShoes(CartDetail);

                return Created(
                    HttpContext.Request.Host.Value,
                    new Response
                    {
                        Success = true,
                        Message = "Add shoes to cart successfully",
                        Data = new { NewCartDetail }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = true,
                    Message = "Error, try again"
                });
            }
        }
    }
}
