using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class ShoesModelDTO
    {
        public int? ShoesModelID { get; set; }

        public string? ShoesModelName { get; set; }

        public BrandDTO? Brand  { get; set; }

        public string? ShoesModelDescription { get; set; }

        public int? ShoesModelStatus { get; set; }

        public List<ShoesDTO>? Shoeses { get; set; }

        public List<ShoesModelImageDTO>? Images { get; set; }
    }
}
