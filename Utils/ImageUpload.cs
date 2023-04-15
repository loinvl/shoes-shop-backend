using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace TheShoesShop_BackEnd.Utils
{
    public class ImageUpload
    {
        private readonly IConfiguration _config;
        private readonly Cloudinary _cloudinary;

        public ImageUpload(IConfiguration config)
        {
            _config = config;

            // new cloundinary with account
            _cloudinary = new Cloudinary(
                new Account(_config["Cloudinary:CloudName"], _config["Cloudinary:APIKey"], _config["Cloudinary:APISecret"]));
        }

        public async Task<string> UploadImage(IFormFile ImageFile)
        {
            // created optionns to upload
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(ImageFile.FileName, ImageFile.OpenReadStream()),
                Folder = "TheShoesShop",
                UseFilename = false,
                Overwrite = true
            };

            // upload to cloudinary server
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            // return url image
            return uploadResult.SecureUrl.ToString();
        }
    }
}
