using System.Collections.Generic;

namespace AdventOfCode2020
{
    public static class Addends
    {
        public static int FindAndMultiply(IEnumerable<int> possibleAddends, int sum)
        {
            foreach (var x in possibleAddends)
            foreach (var y in possibleAddends)
            foreach (var z in possibleAddends)
                if (sum == x + y + z)
                    return x * y * z;

            return 0;
        }
    }
}