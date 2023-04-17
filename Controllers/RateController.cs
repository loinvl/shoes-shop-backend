using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;
        public RateController(TheShoesShopServices TheShoesShopServices) 
        {
            _TheShoesShopServices = TheShoesShopServices;
        }

        // Get rate list of one shoes model
        [HttpGet("shoesmodel/{ShoesModelID}")]
        public async Task<IActionResult> GetRateListOfShoesModel(int ShoesModelID)
        {
            try
            {
                var RateListOfShoesModel = await _TheShoesShopServices._RateService.GetRateListOfShoesModel(ShoesModelID);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get rate list successfully",
                    Data = new { RateListOfShoesModel }
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

        // Add rate when purchased, one rate per one order
        [HttpPost("orderdetail/add")]
        [Authorize]
        public async Task<IActionResult> AddRate(AddingRateDTO Rate)
        {
            try
            {
                // Get auth
                var User = new User(HttpContext.User);

                // Add rate
                var NewRate = await _TheShoesShopServices._RateService.AddRate(Rate, User.CustomerID);
                if(NewRate == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = $"Order with purchase order id={Rate.PurchaseOrderID} and " +
                        $"shoesid id = {Rate.ShoesID} is rated or not belong to you"
                    });
                }

                return Created(
                        HttpContext.Request.Host.Value,
                        new Response
                        {
                            Success = true,
                            Message = "Add new rate successfully",
                            Data = new { NewRate }
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

        // Get one rate of one order detail
        [HttpGet("orderdetail/get/{PurchaseOrderID}/{ShoesID}")]
        [Authorize]
        public async Task<IActionResult> GetRateOfOneOrder(int PurchaseOrderID, int ShoesID)
        {
            try
            {
                // Get auth
                var User = new User(HttpContext.User);

                //
                var Rate = await _TheShoesShopServices._RateService.GetRateOfOneOrder(PurchaseOrderID, ShoesID, User.CustomerID);
                if(Rate == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = $"Order with purchase order id={PurchaseOrderID} and " +
                        $"shoesid id = {ShoesID} is rated or not belong to you"
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get rate of one order detail successfully",
                    Data = new { Rate }
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

        // Get rate  list of one purchase order
        [HttpGet("orderdetail/get/{PurchaseOrderID}")]
        [Authorize]
        public async Task<IActionResult> GetRateListOfPurchase(int PurchaseOrderID)
        {
            try
            {
                // Get auth
                var User = new User(HttpContext.User);

                //
                var RateList = await _TheShoesShopServices._RateService.GetRateListOfPurchase(PurchaseOrderID, User.CustomerID);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get rate of one order detail successfully",
                    Data = new { RateList }
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
