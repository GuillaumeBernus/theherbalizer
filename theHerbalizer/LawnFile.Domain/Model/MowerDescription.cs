using LawnFile.Domain.Extensions;

namespace LawnFile.Domain.Model
{
    /// <summary>
    /// Class MowerDescription.
    /// </summary>
    public class MowerDescription
    {
        /// <summary>
        /// Gets or sets the start position.
        /// </summary>
        /// <value>The start position.</value>
        public string StartPosition { get; set; }

        /// <summary>
        /// Gets or sets the route.
        /// </summary>
        /// <value>The route.</value>
        public string Route { get; set; }

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <returns><c>true</c> if the instance is a valid mower description <c>false</c> otherwise.</returns>
        public bool Check()
        {
            return StartPosition.IsMowerDescription() && Route.IsMowerRoute();
        }
    }
}