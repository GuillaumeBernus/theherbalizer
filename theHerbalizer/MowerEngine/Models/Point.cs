using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    public record Point
    {
        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }

    }
}