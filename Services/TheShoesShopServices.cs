namespace TheShoesShop_BackEnd.Services
{
    public class TheShoesShopServices
    {
        public readonly CustomerService _CustomerService;

        public TheShoesShopServices(CustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }
    }
}
