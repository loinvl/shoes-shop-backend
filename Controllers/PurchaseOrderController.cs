using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;
        public PurchaseOrderController(TheShoesShopServices TheShoesShopServices) 
        {
            _TheShoesShopServices = TheShoesShopServices;
        }


        // Get shoes list to show before checkout
        [HttpGet("shoeses/incart")]
        [Authorize]
        public async Task<IActionResult> GetSomeShoesInCart([FromQuery(Name = "ShoesID")] List<int> ShoesIDs)
        {
            try
            {
                // Check ShoesID list
                if(ShoesIDs.Count == 0)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = $"ShoesID query params is not found",
                    });
                }

                foreach (int ShoesID in ShoesIDs)
                {
                    var Shoes = await _TheShoesShopServices._ShoesService.GetShoesByID(ShoesID);
                    if (Shoes == null)
                    {
                        return BadRequest(new Response
                        {
                            Success = false,
                            Message = $"Shoes is not found with id = {ShoesID}",
                        });
                    }
                }

                // Get some shoes in cart to show
                var User = new User(HttpContext.User);
                List<CartDetailOfCustomerDTO> ShoesList = new List<CartDetailOfCustomerDTO>();
                foreach (int ShoesID in ShoesIDs)
                {
                    var Shoes = await _TheShoesShopServices._CartDetailService.GetOneCartDetailOfCustomer(User.CustomerID, ShoesID);
                    if (Shoes == null)
                    {
                        return BadRequest(new Response
                        {
                            Success = false,
                            Message = $"Shoes with id = {ShoesID} is not exist in cart"
                        });
                    }
                    ShoesList.Add(Shoes);
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get some shoes to checkout successfully",
                    Data = new { ShoesList }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Something error, try again"
                });
            }
        }

        // Checkout
        [HttpPost("checkout")]
        [Authorize]
        public async Task<IActionResult> Checkout(CheckoutDTO Order)
        {
            try
            {
                // Check ShoesID
                if(Order.CheckoutDetails.Count == 0)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Shoes list is empty, can't checkout"
                    });
                }


                // Checkout
                var User = new User(HttpContext.User);
                var NewOrder = await _TheShoesShopServices._PurchaseOrderService.Checkout(User.CustomerID, Order);
                if(NewOrder == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Shoes quantity in warehouse less than you want, please descrease or await"
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Checkout successfully",
                    Data = new { NewOrder }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Something error, try again"
                });
            }
        }
    }
}
