using System.Collections.Generic;

namespace MowerEngine.Models
{
    public class Mower
    {

        public MowerPosition StartPosition { get; set; }

        public IEnumerable<MowerAction> Route { get; set; }

        public Mower Run (Lawn lawn)
        {
            foreach (var action in this.Route)
            {
                var possiblePosition = this.StartPosition.ApplyAction(action);

                if (lawn.Contains(possiblePosition.Position))
                {
                    this.StartPosition = possiblePosition;
                }
            }
            return this;
        }
    }
}