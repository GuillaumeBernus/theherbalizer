﻿using System.Text.RegularExpressions;

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
        public static bool IsLawnDescription(this string line)
        {
            Regex regex = new Regex(@"^\d+ \d+$", RegexOptions.None);

            return regex.IsMatch(line);
        }

        /// <summary>
        /// Determines whether [is mower description] [the specified line].
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><c>true</c> if [is mower description] [the specified line]; otherwise, <c>false</c>.</returns>
        public static bool IsMowerDescription(this string line)
        {
            Regex regex = new Regex(@"^\d+ \d+ (N|E|S|W)$", RegexOptions.None);

            return regex.IsMatch(line);
        }

        /// <summary>
        /// Determines whether [is mower route] [the specified line].
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns><c>true</c> if [is mower route] [the specified line]; otherwise, <c>false</c>.</returns>
        public static bool IsMowerRoute(this string line)
        {
            Regex regex = new Regex(@"^(L|R|F)+$", RegexOptions.None);

            return regex.IsMatch(line);
        }
    }
}