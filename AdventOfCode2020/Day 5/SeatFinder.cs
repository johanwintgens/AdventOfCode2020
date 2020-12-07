using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class SeatFinder
    {
        public static int FindMissing(List<int> seatIds)
        {
            seatIds = seatIds.OrderBy(x => x)
                             .ToList();

            for (var i = 0; i < seatIds.Count; i++)
            {
                if (i == 0 || i == seatIds.Count - 1)
                    continue;

                if (seatIds[i + 1] != seatIds[i] + 1)
                    return seatIds[i] + 1;
            }

            return 0;
        }

        public static int Find(string s)
        {
            s = s.Replace('F', '0')
                 .Replace('B', '1')
                 .Replace('L', '0')
                 .Replace('R', '1');

            var row    = GetRow(s);
            var column = GetColumn(s);

            return row * 8 + column;
        }

        static int GetColumn(string s)
        {
            s = s.Substring(7)
                 .PadLeft(8, '0');

            return BinaryToInt(s);
        }

        static int GetRow(string s)
        {
            s = s.Substring(0, 7)
                 .PadLeft(8, '0');

            return BinaryToInt(s);
        }

        static int BinaryToInt(string s)
        {
            var i = Convert.ToInt32(s, 2);

            return i;
        }
    }
}