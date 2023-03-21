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

        // Get shoes model list by: page, item per page, search, size, color, from, to, brand from instance shoes
        [HttpGet("list")]
        public async Task<IActionResult> GetShoesModelList(
            int PageIndex, int ItemPerPage,
            string? Search,
            int? Size, string? Color,
            int? From, int? To,
            string? Brand,
            int? SortType
        )
        {
            try
            {
                // Find list with property
                var ShoesModelList = await _TheShoesShopServices._ShoesModelService
                    .GetShoesModelList(PageIndex, ItemPerPage, Search, Size, Color, From, To, Brand, SortType);

                // Return result
                return Ok(new Response
                {
                    Success = true,
                    Message = "Request successfully",
                    Data = new { ShoesModelList }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Error something, try to again, never give up"
                });
            }

        }

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
