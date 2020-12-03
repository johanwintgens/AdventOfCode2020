using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_3
{
    public class Map
    {
        char[][] _map;
        int _length;
        int _height;

        public static Map FromLines(ICollection<string> lines)
        {
            var height = lines.Count;
            var length = lines.ElementAt(0).Length;

            char[][] map = lines.Select(x => x.ToCharArray())
                                .ToArray();

            return new Map
            {
                _length = length,
                _height = height,
                _map = map
            };
        }

        public int CountTreesOnSlope(int startX, int startY, int incrementX, int incrementY)
        {
            int x = startX;
            int y = startY;

            int count = 0;
            while (y < _map.Length)
            {
                if (IsTree(x, y))
                    count++;

                x += incrementX;
                y += incrementY;
            }

            return count;
        }

        char GetValue(int x, int y)
        {
            while (x >= _length)
                x -= _length;

            return _map[y][x];
        }

        bool IsTree(int x, int y)
        {
            return GetValue(x, y) == '#';
        }
    }
}