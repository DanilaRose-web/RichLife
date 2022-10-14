using RichLife.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichLife.IUserServices.Models.Response
{
    public class CurrentUserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool TookTheProgram { get; set; }
        public string PhoneNumber { get; set; }
        public string RefferalKey { get; set; }
        public string Gender { get; set; }
        public bool IsAdmin { get; set; }
        public string CodeNumber { get; set; }
    }
}
