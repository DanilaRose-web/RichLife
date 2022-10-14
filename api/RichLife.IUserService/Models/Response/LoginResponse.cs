using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichLife.IUserServices.Models.Response
{
    public class LoginResponse: TokenResponse
    {
        public LoginResponse(TokenResponse response)
        {
            this.Name = response.Name;
            this.Token = response.Token;
            this.IsAdmin = response.IsAdmin;
            this.RefferalLink = response.RefferalLink;
            this.TookTheProgram = response.TookTheProgram;
            this.UserId = response.UserId;
            this.PhoneNumber = response.PhoneNumber;
            this.CodeNumber = response.CodeNumber;
        }
    }
}
