using System.Security.Claims;

namespace TheShoesShop_BackEnd.Auth
{
    public class User
    {
        public int CustomerID { get; set; }
        public string Email { get; set; } = null!;
        public string? AvatarLink { get; set; }

        public User() { }
        public User(ClaimsPrincipal principal)
        {
            CustomerID = int.Parse(principal.FindFirst("CustomerID")!.Value);
            Email = principal.FindFirst("Email")!.Value;
            AvatarLink = principal.FindFirst("AvatarLink")!.Value;
        }
    }
}
