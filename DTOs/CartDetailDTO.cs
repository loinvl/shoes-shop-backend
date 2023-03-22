using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class CartDetailDTO
    {
        public int? CustomerID { get; set; }
        public int? ShoesID { get; set; }
        public int? Quantity { get; set; }
    }
}
