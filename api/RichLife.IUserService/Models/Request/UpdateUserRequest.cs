using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Enum;

namespace RichLife.IUserServices.Models.Request
{
    public class UpdateUserRequest
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? TookTheProgram { get; set; }
        public string CodeNumber { get; set; }
    }
}
