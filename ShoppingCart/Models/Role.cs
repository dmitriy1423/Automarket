using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,

        [Display(Name = "Админ")]
        Admin = 1,
    }
}
