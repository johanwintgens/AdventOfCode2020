using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public static class Duplicates
    {
        public static string Remove(string s)
        {
            return string.Concat(s.Distinct());
        }

        public static int Count(string[] strings)
        {
            return Enumerable.Range(97, 26)
                             .Select(x => (char) x)
                             .Count(x => strings.All(y => y.Contains(x)));
        }
    }
}