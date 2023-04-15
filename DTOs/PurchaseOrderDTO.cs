using System.ComponentModel.DataAnnotations;
using TheShoesShop_BackEnd.Models;

namespace TheShoesShop_BackEnd.DTOs
{
    public class PurchaseOrderDTO
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid purchase order id format")]
        public int? PurchaseOrderID { get; set; }

        public CustomerDTO? Customer { get; set; }
        
        [RegularExpression(@"^[a-zA-ZàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ,.'-]+$", ErrorMessage = "Invalid name format")]
        public string? CustomerName { get; set; }

        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Invalid phone format")]
        public string? Phone { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public DateTime? OrderTime { get; set; }

        public string? Address { get; set; }

        [RegularExpression(@"^[0-5]$", ErrorMessage = "Invalid order status format")]
        public int? OrderStatus { get; set; }

        public string? Note { get; set; }

        public List<OrderDetailDTO> OrderDetail { get; set; } = new List<OrderDetailDTO>();
    }
}
