using System.ComponentModel.DataAnnotations;

namespace RichLife.models
{
    public class DeleteUserRequest
    {
        [Required]
        public long UserId { get; set; }
    }
}
