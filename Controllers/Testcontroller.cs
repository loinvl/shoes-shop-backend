using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.Model;

namespace TheShoesShop_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Testcontroller : ControllerBase
    {
        private static string[] Languages = new string[] { "C#", "Java", "Js", "C++", "Php" };

        private readonly TheShoesShopDbContext _context;

        public Testcontroller(TheShoesShopDbContext context)
        {
            _context = context;
        }

        //Test starting app
        [HttpGet]
        public IEnumerable<HelloWorld> GetHelloWorld()
        {
            return Enumerable.Range(1, Languages.Length).Select(index => new HelloWorld
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
                var customer = _context.customer.ToList();

                return Ok(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex);
            }
        }
    }
}