using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smtp.Mailer.Request
{
    public class GetInTouchRequest
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CodeNumber { get; set; }
        public string Proffesion { get; set; }
        public long Validity { get; set; }
        public string Disease { get; set; }
        public long ProgramAmount { get; set; }
        public string ForWhom { get; set; }
        public string NameOther { get; set; }
        public string DateOfBirthOther { get; set; }
        public string GenderOther { get; set; }
        public string ProffesionOther { get; set; }
        public string DiseaseOther { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Кому отправить
        /// </summary>
        public string EmailFrom { get; set; }
    }
}
