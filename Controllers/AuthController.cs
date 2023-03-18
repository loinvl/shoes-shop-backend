using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.DTOs;
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
        private readonly IMapper _mapper;

        public AuthController(TheShoesShopServices TheShoesShopServices, JWTService JWTService, IMapper mapper)
        {
            _TheShoesShopServices = TheShoesShopServices;
            _JWTService = JWTService;
            _mapper = mapper;
        }

        //login
        [HttpPost("login")]
        public IActionResult Login( LoginDTO LoginInfo)
        {
            try
            {
                var Customer = _TheShoesShopServices._CustomerService.GetCustomerByEmail(LoginInfo.Email);
                
                //Not found out customer
                if (Customer == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Email dont register account",
                    });
                }

                //Found out a customer but invalid password
                if (!BC.Verify(LoginInfo.Password, Customer.HashPassword))
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Incorrect password",
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

        //register
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO RegisterInfo)
        {
            try
            {
                // Check exist customer
                var ExistingCustomer = _TheShoesShopServices._CustomerService.GetCustomerByEmail(RegisterInfo.Email);
                if(ExistingCustomer != null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Email is already register"
                    });
                }

                //call service to create new customer
                var Customer = new customer
                {
                    Email = RegisterInfo.Email,
                    HashPassword = BC.HashPassword(RegisterInfo.Password),
                    CustomerName = RegisterInfo.CustomerName,
                };
                var NewCustomer = _mapper.Map<CustomerDTO>
                    (_TheShoesShopServices._CustomerService.RegisterCustomer(Customer));

                // creating new customer is fail
                if(NewCustomer == null)
                {
                    return StatusCode(500, new Response
                    {
                        Success = false,
                        Message = "Creating new customer is fail, never give up"
                    });
                }

                // creating new customer is success
                
                return Created(
                    HttpContext.Request.Host.Value,
                    new Response
                    {
                        Success = true,
                        Message = "Created account successfully",
                        Data = new { NewCustomer }
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
