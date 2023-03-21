using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesModelController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;

        public ShoesModelController(TheShoesShopServices TheShoesShopServices) 
        {
            _TheShoesShopServices = TheShoesShopServices;
        }

        //[HttpGet("/all")]
        //public async Task<IActionResult> GetShoesList(int PageIndex, int ItemPerPage)
        //{
        //    // 
        //    var ShoesList = TheShoesShop_BackEnd.
        //}

        // Get one shoes model by id
        [HttpGet("{ShoesModelID}")]
        public async Task<IActionResult> GetShoesModelByID(int ShoesModelID)
        {
            try
            {
                var ShoesModel = await _TheShoesShopServices._ShoesModelService.GetShoesModelByID(ShoesModelID);

                // Not found one shoes model by id
                if(ShoesModel == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "Not found any shoes model by id, maybe invalid id"
                    });
                }

                // Found
                return Ok(new Response
                {
                    Success = false,
                    Message = "Get shoes model successfully",
                    Data = new { ShoesModel }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Something error, try to again, never give up"
                });
            }
        }
    }
}
