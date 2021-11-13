using System.Text.RegularExpressions;

namespace LawnFile.Domain.Extensions
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Determines whether [is lawn description] [the specified line].
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><c>true</c> if [is lawn description] [the specified line]; otherwise, <c>false</c>.</returns>
        public static bool IsPointDescription(this string line)
        {
            Regex regex = new Regex(Constants.PointDescriptionRegex, RegexOptions.None);

            return regex.IsMatch(line);
        }

        /// <summary>
        /// Determines whether [is position description] [the specified line].
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><c>true</c> if [is position description] [the specified line]; otherwise, <c>false</c>.</returns>
        public static bool IsPositionDescription(this string line)
        {
            Regex regex = new Regex(Constants.PositionDescriptionRegex, RegexOptions.None);

            return regex.IsMatch(line);
        }

        /// <summary>
        /// Determines whether [is mower route] [the specified line].
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><c>true</c> if [is mower route] [the specified line]; otherwise, <c>false</c>.</returns>
        public static bool IsMowerRoute(this string line)
        {
            Regex regex = new Regex(Constants.RouteDescriptionRegex, RegexOptions.None);

            return regex.IsMatch(line);
        }
    }
}