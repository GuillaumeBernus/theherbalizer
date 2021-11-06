using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawnFile.Domain.Handler
{
    static class StringExtensions
    {

        public static bool IsLawnDescription(this string line)
        {
            Regex regex = new Regex(@"^\d+ \d+$", RegexOptions.None);

            return regex.IsMatch(line);
        }
        public static bool IsMowerDescription(this string line)
        {
            Regex regex = new Regex(@"^\d+ \d+ (N|E|S|W)$", RegexOptions.None);

            return regex.IsMatch(line);
        }  
        
        public static bool IsMowerRoute(this string line)
        {
            Regex regex = new Regex(@"^(L|R|F)+$", RegexOptions.None);

            return regex.IsMatch(line);
        }
    }
}
