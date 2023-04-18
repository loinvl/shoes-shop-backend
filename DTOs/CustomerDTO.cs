using System.ComponentModel.DataAnnotations;

namespace TheShoesShop_BackEnd.DTOs
{
    public class CustomerDTO
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Invalid customer id format")]
        public int? CustomerID { get; set; }

        [RegularExpression(@"^[a-zA-ZàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ ,.'-]+$", ErrorMessage = "Invalid name format")]
        public string? CustomerName { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Invalid phone format")]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? AvatarLink { get; set; }

        [RegularExpression(@"^[0-3]$", ErrorMessage = "Invalid account status format")]
        public int? AccountStatus { get; set; }

        [RegularExpression(@"^[0-1]$", ErrorMessage = "Invalid user role format")]
        public int? UserRole { get; set; }
    }
}
