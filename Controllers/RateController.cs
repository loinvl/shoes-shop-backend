using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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
        [HttpGet("{ShoesModelID}")]
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
    }
}
