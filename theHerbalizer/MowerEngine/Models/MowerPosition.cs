using System.ComponentModel.DataAnnotations;

namespace MowerEngine.Models
{
    public record MowerPosition
    {
        [Required]
        public Point Coordinates { get; set; }
        [Required]
        public Direction Orientation { get; set; }

        //public override string ToString()
        //{
        //    return $"{Coordinates?.ToString() ?? String.Empty} {Orientation}";
        //}
    }
}