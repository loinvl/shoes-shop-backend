namespace TheShoesShop_BackEnd.DTOs
{
    public class CartDetailOfCustomerDTO
    {
        public ShoesModelDTO? ShoesModel { get; set; }
        public ShoesDTO? Shoes { get; set; } 
        public int? Quantity { get; set; }
    }
}
