namespace TheShoesShop_BackEnd.Services
{
    public class TheShoesShopServices
    {
        public readonly CustomerService _CustomerService;
        public readonly ShoesModelService _ShoesModelService;

        public TheShoesShopServices(CustomerService CustomerService, ShoesModelService ShoesModelService)
        {
            _CustomerService = CustomerService;
            _ShoesModelService = ShoesModelService;
        }
    }
}
