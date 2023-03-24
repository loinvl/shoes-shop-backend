using System.ComponentModel.DataAnnotations;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class AddingRateDTO
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid purchase order id format")]
        public int? PurchaseOrderID { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid shoes id format")]
        public int? ShoesID { get; set; }

        [RegularExpression(@"^[1-5]$", ErrorMessage = "Invalid number of star format")]
        public int? RateStar { get; set; }

        public string? Content { get; set; }

        public string? ImageLink { get; set; }
    }
}
