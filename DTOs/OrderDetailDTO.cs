using System.ComponentModel.DataAnnotations;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class OrderDetailDTO
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid order detail id format")]
        public int? PurchaseOrderID { get; set; }

        public ShoesModelDTO? ShoesModel { get; set; }
        public ShoesDTO? Shoes { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid unit price format")]
        public int? UnitPrice { get; set; }

        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid quantity format")]
        public int? Quantity { get; set; }
    }
}
