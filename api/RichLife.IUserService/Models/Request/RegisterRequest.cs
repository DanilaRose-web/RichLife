using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Enum;

namespace RichLife.IUserServices.Models.Request
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string RefferalKey { get; set; }
        public string Gender { get; set; }
        public string CodeNumber { get; set; }
    }
}
