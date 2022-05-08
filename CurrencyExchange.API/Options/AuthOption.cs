using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CurrencyExchange.API.Options
{
    public class AuthOption
    {
        public const string ISSUER = "https://localhost:44369";
        public const string AUDIENCE = "https://localhost:44369";
        const string KEY = "cakjdnclkaejnfkj4nfw498fqae_8haecq32d2cadn_ciuenqivbirvowberivne";
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
