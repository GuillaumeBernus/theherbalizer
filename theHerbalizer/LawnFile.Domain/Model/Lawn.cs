using LawnFile.Domain.Handler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain.Model
{
    public class Lawn
    {
        public Point UpperRigthCorner { get; set; }
        public IEnumerable<Mower> Mowers { get; set; }

        internal static Lawn FromLawnDescription(LawnDescription lawnDescription)
        {

            return new Lawn
            {
                UpperRigthCorner=Point.FromPointDescription(lawnDescription.UpperRightCorner),
                Mowers=Mower.FromMowerDescriptionList(lawnDescription.MowerDescriptions)
            };
        }
    }
}
