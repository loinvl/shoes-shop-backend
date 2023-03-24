using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class RateDTO
    {
        public int? RateID { get; set; }

        public CustomerDTO? Customer { get; set; }

        public int? RateStar { get; set; }

        public string? Content { get; set; }

        public DateTime? RateTime { get; set; }
    }
}
