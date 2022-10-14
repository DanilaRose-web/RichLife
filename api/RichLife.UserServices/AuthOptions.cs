using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RichLife.UserServices
{
    public class AuthOptions
    {
        public const string ISSUER = "zeexs"; // издатель токена
        public const string AUDIENCE = "zeexs2"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123"; // ключ для шифрации
        public const int LIFETIME = 10000; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));

    }
}
