namespace TheShoesShop_BackEnd.Services
{
    public class TheShoesShopServices
    {
        public readonly CustomerService _CustomerService;
        public readonly ShoesModelService _ShoesModelService;
        public readonly ShoesService _ShoesService;
        public readonly CartDetailService _CartDetailService;
        public readonly PurchaseOrderService _PurchaseOrderService;

        public TheShoesShopServices(
            CustomerService CustomerService, 
            ShoesModelService ShoesModelService,
            ShoesService ShoesService,
            CartDetailService CartDetailService,
            PurchaseOrderService PurchaseOrderService
        )
        {
            _CustomerService = CustomerService;
            _ShoesModelService = ShoesModelService;
            _ShoesService = ShoesService;
            _CartDetailService = CartDetailService;
            _PurchaseOrderService = PurchaseOrderService;
        }
    }
}
