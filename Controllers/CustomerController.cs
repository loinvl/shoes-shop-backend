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
    public class CustomerController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;

        public CustomerController(TheShoesShopServices TheShoesShopServices) {
            _TheShoesShopServices = TheShoesShopServices;
        }

        // Get profile
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                // Get user
                var User = new User(HttpContext.User);

                // Get info
                var Profile = await _TheShoesShopServices._CustomerService.GetProfileByID(User.CustomerID);
                if(Profile == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid input",
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get profile successfully",
                    Data = new { Profile }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response 
                { 
                    Success = false,
                    Message = "Get profile is failture"
                });
            }
        }


        // Update profile
        [HttpPatch("profile/update")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(CustomerDTO Profile)
        {
            try
            {
                // Get user
                var User = new User(HttpContext.User);
                Profile.CustomerID = User.CustomerID;

                // Update profile
                var NewProfile = await _TheShoesShopServices._CustomerService.UpdateProfileByID(Profile);
                if (NewProfile == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid input",
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Update profile successfully",
                    Data = new { NewProfile }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Get profile is failture"
                });
            }
        }
    }
}
