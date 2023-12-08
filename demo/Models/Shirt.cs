using System.ComponentModel.DataAnnotations;
using demo.Models.Validations;

namespace demo.Models
{
    public class Shirt
    {
        [Required]
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }

        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }
        [Required, StringLength(10)]
        public string? Gender { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
