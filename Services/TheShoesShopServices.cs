namespace TheShoesShop_BackEnd.Services
{
    public class TheShoesShopServices
    {
        public readonly CustomerService _CustomerService;
        public readonly ShoesModelService _ShoesModelService;
        public readonly ShoesService _ShoesService;
        public readonly CartDetailService _CartDetailService;
        public readonly PurchaseOrderService _PurchaseOrderService;
        public readonly RateService _RateService;
        public readonly BrandService _BrandService;

        public TheShoesShopServices(
            CustomerService CustomerService, 
            ShoesModelService ShoesModelService,
            ShoesService ShoesService,
            CartDetailService CartDetailService,
            PurchaseOrderService PurchaseOrderService,
            RateService RateService,
            BrandService BrandService
        )
        {
            _CustomerService = CustomerService;
            _ShoesModelService = ShoesModelService;
            _ShoesService = ShoesService;
            _CartDetailService = CartDetailService;
            _PurchaseOrderService = PurchaseOrderService;
            _RateService = RateService;
            _BrandService = BrandService;
        }
    }
}
