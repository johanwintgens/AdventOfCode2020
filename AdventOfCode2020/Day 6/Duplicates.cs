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
    }
}