using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Mailer.Request
{
    public class ForgotPasswordMail
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public Guid Toke { get; set; }
    }
}
