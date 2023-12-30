using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Минимум 2 символа")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Минимум 4 символа")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
