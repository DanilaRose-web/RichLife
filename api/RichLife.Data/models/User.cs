using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Enum;

namespace RichLife.Data.models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool TookTheProgram { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordKey { get; set; }
        public string RefferalKey { get; set; }
        public UserRole Role { get; set; }
        public string CodeNumber { get; set; }
        public string Gender { get; set; }
        public List<UserToken> UserTokens { get; set; }
        public bool IsDelete { get; set; }
    }
}
