using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheShoesShop_BackEnd.DTOs;
using TheShoesShop_BackEnd.Models;
using TheShoesShop_BackEnd.Utils;

namespace TheShoesShop_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly TheShoesShopDbContext _TheShoesShopDbContext;
        private readonly ImageUpload _ImageUpload;

        public FileController(TheShoesShopDbContext TheShoesShopDbContext, ImageUpload ImageUpload)
        {
            _TheShoesShopDbContext = TheShoesShopDbContext;
            _ImageUpload = ImageUpload;
        }

        // upload one image to cloudinary
        [HttpPost("image/upload")]
        public async Task<IActionResult> UploadOneImage(IFormFile ImageFile)
        {
            try
            {
                var ImageLink = await _ImageUpload.UploadImage(ImageFile);

                return Ok(new Response
                {
                    Success = true,
                    Message = "Upload image is success",
                    Data = new { ImageLink }
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new Response
                {
                    Success = false,
                    Message = "Upload image is fail, try again"
                });
            }
        }
    }
}
