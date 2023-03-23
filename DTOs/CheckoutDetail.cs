using System.ComponentModel.DataAnnotations;

namespace TheShoesShop_BackEnd.DTOs
{
    public class CheckoutDetail
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid shoes id format")]
        public int? ShoesID { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid quantity format")]
        public int? Quantity { get; set; }
    }
}
