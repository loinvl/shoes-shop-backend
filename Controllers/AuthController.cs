using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Services;
using BC = BCrypt.Net.BCrypt;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TheShoesShopServices _TheShoesShopServices;
        private readonly JWTService _JWTService;

        public AuthController(TheShoesShopServices TheShoesShopServices, JWTService JWTService)
        {
            _TheShoesShopServices = TheShoesShopServices;
            _JWTService = JWTService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginForm LoginForm)
        {
            try
            {
                var Customer = _TheShoesShopServices._CustomerService.GetCustomerByEmail(LoginForm.Email);
                
                //Not found out customer
                if (Customer == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid email",
                    });
                }

                //Found out a customer but invalid password
                if (!BC.Verify(LoginForm.Password, Customer.HashPassword))
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid password",
                    });
                }

                //valid
                var User = new User { CustomerID = Customer.CustomerID, Email = Customer.Email };
                var Token = _JWTService.GenerateAccessToken(User);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Login successfully",
                    Data = new { Token }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
