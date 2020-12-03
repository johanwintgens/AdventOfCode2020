using System;

namespace AdventOfCode2020
{
    public class Password
    {
        public string Value { get; }
        public char KeyChar { get; }
        public int Index1 { get; }
        public int Index2 { get; }

        public Password(string value, char keyChar, int index1, int index2)
        {
            Value = value;
            KeyChar = keyChar;
            Index1 = index1;
            Index2 = index2;
        }

        public bool IsValid()
        {
            int matches = 0;

            if (Value[Index1] == KeyChar)
                matches++;

            if (Value[Index2] == KeyChar)
                matches++;

            return matches == 1;
        }

        public static Password FromLine(string line)
        {
            var spaceSeparated = line.Split(' ');

            var limits = spaceSeparated[0].Split('-');
            var minOccurrence = Convert.ToInt32(limits[0]) - 1;
            var maxOccurrence = Convert.ToInt32(limits[1]) - 1;

            var keyChar = spaceSeparated[1][0];

            var value = spaceSeparated[2];

            return new Password(value, keyChar, minOccurrence, maxOccurrence);
        }
    }
}