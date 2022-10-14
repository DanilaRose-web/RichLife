using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Smtp.Mailer.Request;

namespace Smtp.Mailer
{
    /// <summary>
    /// Todo Статика пока не заплотют 
    /// </summary>
    public class MailService
    {
        private static string From => "richlifedevelop@gmail.com";
        private static string Password => "8r5h4tx$Kdeq?z8s";

        private static List<(string, string)> ReplaceList => new List<(string, string)>
        {
            ("domain","http://31.31.24.200:5051"),
        };
        public async Task ForgotPasswordMail(ForgotPasswordMail request)
        {
            await this.SendEvent(request.Email, "forgotpassword", new List<KeyValuePair<string, string>>
            {
                new("code", request.Code),
                new("token", request.Toke.ToString("D"))
            });
        }

        public async Task SendMessage(SendMessageRequest request)
        {
            await this.SendEvent(request.EmailFrom, "SendMessage",
                new List<KeyValuePair<string, string>>
                {
                    new("Name", request.Name ?? ""),
                    new("SurName", request.SurName ?? ""),
                    new("Phone", request.Phone ?? ""),
                    new("Email", request.Email ?? ""),
                    new("Message", request.Message ?? ""),
                    new("CodeNumber", request.CodeNumber ?? ""),
                });
        }
        public async Task WelcomeMail(WelcomeEmail request)
        {
            await this.SendEvent(request.Email, "welcomeemail", new List<KeyValuePair<string, string>>
            {
                new("email", request.Email),
                new("password", request.Password)
            });
        }
        public async Task GetInTouch(GetInTouchRequest request)
        {
            await this.SendEvent(request.EmailFrom, "getintouch", new List<KeyValuePair<string, string>>
            {
                new("Name", request.Name ?? ""),
                new("DateOfBirth", request.DateOfBirth ?? ""),
                new("Gender", request.Gender ?? ""),
                new("Proffesion", request.Proffesion ?? ""),
                new("Validity", request.Validity.ToString("D") ?? ""),
                new("Disease", request.Disease ?? ""),
                new("ProgramAmount", request.ProgramAmount.ToString() ?? ""),
                new("ForWhom", request.ForWhom ?? ""),
                new("NameOther", request.NameOther ?? ""),
                new("DateOfBirthOther", request.DateOfBirthOther ?? ""),
                new("GenderOther", request.GenderOther ?? ""),
                new("ProffesionOther", request.ProffesionOther ?? ""),
                new("DiseaseOther", request.Phone ?? ""),
                new("Email", request.Email ?? ""),
                new("CodeNumber", request.CodeNumber ?? ""),
            });
        }
        public async Task SendEvent(string email,string eventName,List<KeyValuePair<string,string>> replaceValue)
        {
            var body = await this.GetTrigger(eventName);
            SendMail(email, EventLsit[eventName].caption, UpdateBody(body, replaceValue));
        }
        private void SendMail(string mailto, string caption, string message)
        {
            try
            {
                using var mail = new MailMessage();
                mail.From = new MailAddress(From);
                mail.To.Add(new MailAddress(Regex.Replace(mailto, @"\+(.*)\@", "@")));
                mail.Subject = caption;
                mail.IsBodyHtml = true;
                mail.Body = message;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(From, Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
            }
            catch (Exception e)
            {
                //_logger.Info("GMail not sent error:"+e.Message);
            }
        }
        private string UpdateBody(string message, List<KeyValuePair<string, string>> list)
        {
            list.ForEach(x => { message = message.Replace(ConvertKey(x.Key), x.Value); });
            ReplaceList.ForEach(x => { message = message.Replace(ConvertKey(x.Item1), x.Item2); });
            return message;
        }
        private string ConvertKey(string key) => $"*|{key}|*";
        private static Dictionary<string, (string path, string caption)> EventLsit =>
            new Dictionary<string, (string path, string caption)>()
            {
                {
                    "forgotpassword", ("wwwroot\\EmailTriggers\\forgot-password.html", "Forgot Password Dev")
                },
                {
                    "getintouch", ("wwwroot\\EmailTriggers\\GetInTouch.html", "GetInTouch Dev")
                },
                {
                    "welcomeemail", ("wwwroot\\EmailTriggers\\registered.html", "Welcome")
                },
                {
                    "SendMessage", ("wwwroot\\EmailTriggers\\chat-form.html", "Welcome")
                }
            };
        private async Task<string> GetTrigger(string triggerName)
        {
            if (string.IsNullOrWhiteSpace(triggerName))
                throw new Exception("тригер не найден");
            if (!EventLsit.ContainsKey(triggerName))
                throw new Exception("тригер не поддерживается");
            using var reader = new StreamReader(EventLsit[triggerName].path);
            return await reader.ReadToEndAsync();
        }
    }
}
