using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LawnFile.Domain
{
    /// <summary>
    /// Class Constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The position description members count
        /// </summary>
        public static readonly int PositionDescriptionMembersCount = 3;

        /// <summary>
        /// The point description regex
        /// </summary>
        internal static readonly string PointDescriptionRegex = @"^\d+ \d+$";

        /// <summary>
        /// The position description regex
        /// </summary>
        internal static readonly string PositionDescriptionRegex = @"^\d+ \d+ (N|E|S|W)$";

        /// <summary>
        /// The route description regex
        /// </summary>
        internal static readonly string RouteDescriptionRegex = @"^(L|R|F)+$";
    }
}