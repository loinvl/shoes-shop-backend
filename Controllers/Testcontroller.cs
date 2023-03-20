using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Services;

namespace TheShoesShop_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static string[] Languages = new string[] { "C#", "Java", "Js", "C++", "Php" };
        private readonly TheShoesShopServices _TheShoesShopServices;

        public TestController(TheShoesShopServices TheShoesShopServices)
        {
            _TheShoesShopServices = TheShoesShopServices;
        }

        //Test starting app
        [HttpGet]
        public IEnumerable<HelloWorldDTO> GetHelloWorld()
        {
            return Enumerable.Range(1, Languages.Length).Select(index => new HelloWorldDTO
            {
                ID = index,
                Language = Languages[index - 1],
                HiSentence = Languages[index - 1],
            })
            .ToArray();
        }

        //Test connecting database
        [HttpGet("database")]
        public IActionResult TestingConnectDatabase()
        {
            try
            {
                var customer = _TheShoesShopServices._CustomerService.GetAllCustomer();

                return Ok(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex);
            }
        }

        //Test authentication
        [HttpGet("api/customer/info")]
        [Authorize]
        public IActionResult GetCustomer()
        {
            try
            {
                var User = new TheShoesShop_BackEnd.Auth.User(HttpContext.User);
                var Customer = _TheShoesShopServices._CustomerService.GetCustomerById(User.CustomerID);  
                
                if(Customer == null)
                {
                    return NotFound(new Response
                    {
                        Success = false,
                        Message = "Dont exist customer with that ID"
                    });
                }

                return Ok(new Response
                {
                    Success = true,
                    Message = "Get customer successfully",
                    Data = new { Customer },
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new Response
                {
                    Success = false,
                    Message = "Error something, please try to again"
                });
            }
        }
    }
}