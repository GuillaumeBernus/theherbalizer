using System;
using System.Linq;

namespace MowerEngine.Models
{
    public static class StringExtensions
    {
        public static bool IsRotationDescription(this string stringMove)
        {
            char[] allowed = { Constants.LeftRotationCharacter, Constants.RightRotationCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }

        public static bool IsFrontMoveDescription(this string stringMove)
        {
            char[] allowed = { Constants.FrontMoveCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }

        public static bool IsTravelDescription(this string stringMove)
        {
            char[] allowed = { Constants.LeftRotationCharacter, Constants.RightRotationCharacter, Constants.FrontMoveCharacter };
            return !String.IsNullOrEmpty(stringMove) && !stringMove.Any(c => !allowed.Contains(c));
        }
    }
}