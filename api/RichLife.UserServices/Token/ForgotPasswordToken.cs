using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Data;
using RichLife.Enum;

namespace RichLife.UserServices.Token
{
    public class ForgotPasswordToken: IUserTokenUpdater
    {
        private DataContext _db = new DataContext();
        public TokenType Type => TokenType.ForgotPassword;
        public bool SetToken(Guid token, object request)
        {
            var userToken = _db.UserTokens.Find(token);
            return userToken is not null 
                   && request is string code 
                   && userToken.Code == code;
        }
    }
}
