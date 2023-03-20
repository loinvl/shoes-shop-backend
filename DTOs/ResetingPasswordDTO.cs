using System.ComponentModel.DataAnnotations;

namespace TheShoesShop_BackEnd.DTOs
{
    public class ResetingPasswordDTO
    {
        public string? Token { get; set; }

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[~!@#$%^&*()_+])[A-Za-z\d~!@#$%^&*()_+]{8,}$", ErrorMessage = "Invalid password format")]
        public string? NewPassword { get; set; }
    }
}
