using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace TheShoesShop_BackEnd.Auth
{
    public class JWTService
    {
        private readonly IConfiguration _config;

        public JWTService(IConfiguration config) {
            _config = config;
        }

        private Claim[] GenerateClaimsFromObject(object Obj)
        {
            PropertyInfo[] properties = Obj.GetType().GetProperties();
            Claim[] Claims = new Claim[properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                var name = properties[i].Name;
                var value = properties[i].GetValue(Obj, null)!.ToString();
                Claims[i] = new Claim(name, value!);
            }

            return Claims;
        }

        public string GenerateToken(object Obj, int ExpToken)
        {
            var Issuer = _config["JWT:Issuer"];
            var Audience = _config["JWT:Audience"];
            var SecretKey = _config["JWT:SecretKey"];
            var SecretKeyBytes = Encoding.UTF8.GetBytes(SecretKey!);

            var TokenHandler = new JwtSecurityTokenHandler();

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GenerateClaimsFromObject(Obj)),
                Audience = Audience,
                Issuer = Issuer,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(SecretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddMinutes(ExpToken)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            
            return TokenHandler.WriteToken(Token);
        }

        public ClaimsPrincipal? ValidateToken(string? Token)
        {
            try
            {
                // When valid token
                var SecretKey = _config["JWT:SecretKey"];
                var ValidIssuer = _config["JWT:Issuer"];
                var ValidAudience = _config["JWT:Audience"];

                var TokenHandler = new JwtSecurityTokenHandler();
                var SecretKeyBytes = Encoding.UTF8.GetBytes(SecretKey!);
                var ValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ValidIssuer,

                    ValidateAudience = true,
                    ValidAudience = ValidAudience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKeyBytes),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                SecurityToken ValidatedToken;
                var Principal = TokenHandler.ValidateToken(Token, ValidationParameters, out ValidatedToken);

                return Principal;
            }
            catch(Exception ex)
            {
                // When invalid token
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
