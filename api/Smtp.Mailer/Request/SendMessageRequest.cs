using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Mailer.Request
{
    public class SendMessageRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CodeNumber { get; set; }
        /// <summary>
        /// куда отправить
        /// </summary>
        public string EmailFrom { get; set; }
        public string Message { get; set; }
    }
}
