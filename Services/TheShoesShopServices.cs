namespace TheShoesShop_BackEnd.Services
{
    public class TheShoesShopServices
    {
        public readonly CustomerService _CustomerService;
        public readonly ShoesModelService _ShoesModelService;

        public TheShoesShopServices(ShoesModelService ShoesModelService)
        {
            _ShoesModelService = ShoesModelService;
        }
    }
}
