using ShoppingCart.Context.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Минимум 2 символа")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите скорость")]
        [Display(Name = "Максимальная скорость")]
        public double Speed { get; set; }

        [Required(ErrorMessage = "Введите стоимость")]
        [Display(Name = "Стоимость")]
        public double Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Выберите категорию")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; } = "noimage.png";

        public int CountSales { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

    }
}
