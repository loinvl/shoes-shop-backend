using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TheShoesShop_BackEnd.Auth;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Services;
using TheShoesShop_BackEnd.Utils;
using BC = BCrypt.Net.BCrypt;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly TheShoesShopServices _TheShoesShopServices;
        private readonly JWTService _JWTService;
        private readonly IMapper _mapper;
        private readonly SendingEmail _SendingEmail;
        private readonly RedisTokenBlacklist _Redis;

        public AuthController(
            IConfiguration config, 
            TheShoesShopServices TheShoesShopServices, 
            JWTService JWTService, 
            IMapper mapper,
            SendingEmail SendingEmail,
            RedisTokenBlacklist Redis
        )
        {
            _config = config;
            _TheShoesShopServices = TheShoesShopServices;
            _JWTService = JWTService;
            _mapper = mapper;
            _SendingEmail = SendingEmail;
            _Redis = Redis;
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
                        Message = "Email chưa được đăng ký",
                    });
                }

                //Found out a customer but invalid password
                if (!BC.Verify(LoginInfo.Password, Customer.HashPassword))
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Mật khẩu không chính xác",
                    });
                }

                //valid
                var User = new User { CustomerID = Customer.CustomerID, Email = Customer.Email };
                var ExpAccessToken = int.Parse(_config["JWT:AccessTokenValidityInMinutes"]!);
                var ExpRefreshToken = int.Parse(_config["JWT:RefreshTokenValidityInMinutes"]!);
                var AccessToken = _JWTService.GenerateToken(User, ExpAccessToken);
                var RefreshToken = _JWTService.GenerateToken(User, ExpRefreshToken);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Login successfully",
                    Data = new { AccessToken, RefreshToken }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO RegisterInfo)
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
                var NewCustomer = await _TheShoesShopServices._CustomerService.RegisterCustomer(RegisterInfo);

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

        // Send link to email to reser password
        [HttpPost("password/forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] Dictionary<string, string> Data) 
        {
            try
            {
                // Get Email from json data
                Data.TryGetValue("email", out var Email);

                // Check customer with email provide
                var Customer = _TheShoesShopServices._CustomerService.GetCustomerByEmail(Email);

                // Email dont regiter account
                if (Customer == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Email incorrect that never use to register account",
                        ErrorCode = 1
                    });
                }

                // Customer exist, setup data that use send to user
                // Generate token that to user reset password
                var ExpToken = 5;
                var Token = _JWTService.GenerateToken
                    (new User { CustomerID = Customer.CustomerID, Email = Customer.Email }, ExpToken);
                var FrontendHost = _config["AnotherDomain:TheShoesShopFrontend"];
                var ToEmail = Customer.Email;
                var Subject = "Reset password";
                var Content = $"Hi {Customer.CustomerName}!<br/>" +
                    $"This below link use to reset password, After 5 minutes, link has expired.<br/>" +
                    $"Note important, dont share that link to anyone to security of your account.<br/>" +
                    $"Link: {FrontendHost}/auth/reset-password?token={Token}";

                // Send email to user
                var SentStatus = await _SendingEmail.SendToEmail(ToEmail, Subject, Content);

                // Error in sending process
                if (!SentStatus)
                {
                    return StatusCode(500, new Response
                    {
                        Success = false,
                        Message = "Falture in sending email process, try to again, never give up",
                        ErrorCode = 500
                    });
                }

                // Sending success
                return Ok(new Response
                {
                    Success = true,
                    Message = "A link reset password sent to your email, please check it"
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex.ToString());
            }

        }

        // Reset password
        [HttpPost("password/reset")]
        public async Task<IActionResult> ResetPassword(ResetingPasswordDTO Info)
        {
            try
            {
                // Verify token
                var Claims = _JWTService.ValidateToken(Info.Token);
                if (Claims == null)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid token",
                        ErrorCode = 1
                    });
                }

                // Success, convert and reset password
                var User = new User(Claims);
                var ResetStatus = await _TheShoesShopServices._CustomerService.ResetPassword(User.CustomerID, Info.NewPassword);

                // Error below database
                if (!ResetStatus)
                {
                    return BadRequest(new Response
                    {
                        Success = false,
                        Message = "Invalid input, try to again, never give up",
                        ErrorCode = 2
                    });
                }

                //
                return Ok(new Response
                {
                    Success = true,
                    Message = "Reset password successfully"
                });
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Error server, try to again, never give up",
                    ErrorCode = 500
                });
            }
        }

        // Refresh access token with refresh token
        [HttpPost("token/refresh")]
        public IActionResult RefreshAccessToken([FromBody] Dictionary<string, string> Data)
        {
            try
            {
                // Get refresh tokent from data post
                Data.TryGetValue("refreshToken", out var RefreshToken);

                //Verify refresh token
                var Claims = _JWTService.ValidateToken(RefreshToken);

                // Verifing is fail cause token has expired or invalid
                if (Claims == null)
                {
                    return Unauthorized(new Response
                    {
                        Success = false,
                        Message = "Refresh token has expired or invalid, please login",
                    });
                }

                // Generate new refresh token and new access token
                var User = new User(Claims);
                var ExpAccessToken = int.Parse(_config["JWT:AccessTokenValidityInMinutes"]!);
                var ExpRefreshToken = int.Parse(_config["JWT:RefreshTokenValidityInMinutes"]!);
                var NewAccessToken = _JWTService.GenerateToken(User, ExpAccessToken);
                var NewRefreshToken = _JWTService.GenerateToken(User, ExpRefreshToken);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Generate successfully",
                    Data = new { NewAccessToken, NewRefreshToken }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Error some thing, try to again, never give up"
                });
            }
        }

        // Logout by to token to blacklist token
        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // Get tokent from 
            var BearerToken = Request.Headers["Authorization"].ToString();
            var Token = BearerToken.Substring(BearerToken.IndexOf(" ") + 1);
            var ExpTimeToken = TimeSpan.FromTicks(int.Parse(HttpContext.User.FindFirstValue("exp")));

            // Let token into blacklist
            await _Redis.AddToBlacklistAsync(Token, ExpTimeToken);

            return Ok(new Response
            {
                Success = true,
                Message = "Logout successfully, token is revoked"
            });
        }
        
    }
}
