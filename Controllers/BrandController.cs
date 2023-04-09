using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;

        public BrandController(TheShoesShopServices TheShoesShopServices) 
        {
            _TheShoesShopServices = TheShoesShopServices;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetBrandList()
        {
            try
            {
                var BrandList = await _TheShoesShopServices._BrandService.GetBrandList();

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get brand list successfully",
                    Data = new { BrandList }
                });
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Server error, try again"
                });
            }
        }
    }
}
