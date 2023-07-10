using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend.Services.Auth
{
    public class AuthOptions
    {
        public string Issuer { get; set; } = "IssuerString";

        public string Audience { get; set; } = "AudienceString";

        public string Key { get; set; } = "SecretKey";

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(Key));
    }
}
