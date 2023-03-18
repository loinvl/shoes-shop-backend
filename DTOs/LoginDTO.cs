﻿using System.ComponentModel.DataAnnotations;

namespace TheShoesShop_BackEnd.DTOs
{
    public class LoginDTO
    {
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[~!@#$%^&*()_+])[A-Za-z\d~!@#$%^&*()_+]{8,}$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; } = null!;
    }
}
