using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Data.models;
using RichLife.Enum;

namespace RichLife.UserServices
{
    public interface IUserTokenUpdater
    {
        public TokenType Type { get; }
        public bool SetToken(Guid token, object request);

    }
}
