using System;
using System.Linq;

namespace MowerEngine.Models
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether [is rotation description] [the specified string move].
        /// </summary>
        /// <param name="stringMove">The string move.</param>
        /// <returns><c>true</c> if [is rotation description] [the specified string move]; otherwise, <c>false</c>.</returns>
        public static bool IsRotationDescription(this string stringMove)
        {
            char[] allowed = { Constants.LeftRotationCharacter, Constants.RightRotationCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }

        /// <summary>
        /// Determines whether [is front move description] [the specified string move].
        /// </summary>
        /// <param name="stringMove">The string move.</param>
        /// <returns><c>true</c> if [is front move description] [the specified string move]; otherwise, <c>false</c>.</returns>
        public static bool IsFrontMoveDescription(this string stringMove)
        {
            char[] allowed = { Constants.FrontMoveCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }

        /// <summary>
        /// Determines whether [is travel description] [the specified string move].
        /// </summary>
        /// <param name="stringMove">The string move.</param>
        /// <returns><c>true</c> if [is travel description] [the specified string move]; otherwise, <c>false</c>.</returns>
        public static bool IsTravelDescription(this string stringMove)
        {
            char[] allowed = { Constants.LeftRotationCharacter, Constants.RightRotationCharacter, Constants.FrontMoveCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }
    }
}