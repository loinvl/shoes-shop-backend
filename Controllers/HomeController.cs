using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string GetHome()
        {
            string Welcome = "Welcome to The Shoes Shop api!";
            return Welcome;
        }
    }
}
