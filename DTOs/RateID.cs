using System.ComponentModel.DataAnnotations;

namespace TheShoesShop_BackEnd.DTOs
{
    public class RateID
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid purchase order id format")]
        public int? PurchaseOrderID { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid shoes id format")]
        public int? ShoesID { get; set; }
    }
}
