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
        [HttpPost("add")]
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
                        Message = $"Purchase order with id={Rate.PurchaseOrderID} is rated or not belong to you"
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
    }
}
