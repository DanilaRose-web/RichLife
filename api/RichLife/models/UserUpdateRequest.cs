using System.ComponentModel.DataAnnotations;
using RichLife.Enum;

namespace RichLife.models
{
    /// <summary>
    /// Обновить данные о пользователе
    /// </summary>
    public class UserUpdateRequest
    {
        /// <summary>
        /// Какого пользователя меняем
        /// </summary>
        [Required]
        public long UserId { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Новый емаил пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона ползователя
        /// </summary>
        public string Phone { get; set; }
        public string CodeCountry { get; set; }
    }
}
