using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace MowerEngine.Models
{
    public class Lawn
    {
        [Required]
        public Point UpperRigthCorner { get; set; }

        [Required]
        public List<Mower> Mowers { get; set; }



        public Lawn()
        {

        }
        [JsonConstructor()]
        public Lawn(List<Mower> mowers ):base()
        {
            mowers.ForEach(m => m.Lawn = this);
            this.Mowers = mowers;
        }

        public List<MowerPosition> RunMowers()
        {
            var result = new List<MowerPosition>(Mowers.Count);

            foreach (var mower in Mowers)
            {
                result.Add(mower.Run().Position);
            }

            return result;
        }

        internal bool Contains(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X <= this.UpperRigthCorner.X && point.Y <= this.UpperRigthCorner.Y;
        }
    }
}
