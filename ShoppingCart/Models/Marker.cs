using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Marker
    {
        public int Id { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
