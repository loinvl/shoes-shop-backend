using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.Model;

namespace TheShoesShop_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private static string[] Languages = new string[] { "C#", "Java", "Js", "C++", "Php" };

        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HelloWorld> Get()
        {
            return Enumerable.Range(1, Languages.Length).Select(index => new HelloWorld
            {
                ID = index,
                Language = Languages[index - 1],
                HiSentence = Languages[index - 1],
            })
            .ToArray();
        }
    }
}