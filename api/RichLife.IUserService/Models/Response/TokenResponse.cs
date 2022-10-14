using RichLife.Enum;

namespace RichLife.IUserServices.Models.Response
{
    public class TokenResponse
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool TookTheProgram { get; set; }
        public string RefferalLink { get; set; }
        public string PhoneNumber { get; set; }
        public string CodeNumber { get; set; }
    }
}
