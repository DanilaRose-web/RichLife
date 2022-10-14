using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichLife.IUserServices.Models.Request
{
    public class ForgotPasswordConfirmRequest
    {
        public Guid Toke { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPAssword { get; set; }
    }
}
