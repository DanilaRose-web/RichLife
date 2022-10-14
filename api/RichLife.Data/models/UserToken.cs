using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Enum;

namespace RichLife.Data.models
{
    public class UserToken
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public TokenType Type { get; set; }
        public string Code { get; set; }
    }
}
