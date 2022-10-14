using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Data;
using RichLife.Enum;

namespace RichLife.UserServices.Token
{
    public class ActivateUser: IUserTokenUpdater
    {
        private DataContext _db = new DataContext();
        public TokenType Type => TokenType.ActivateAccount;
        public bool SetToken(Guid token, object request)
        {
            var tokens = _db.UserTokens.Find(token);
            if (tokens != null)
            {
                return true;
                /// активирован и все)
            }

            return false;
        }
    }
}
