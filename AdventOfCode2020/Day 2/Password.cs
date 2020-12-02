using System;
using System.Linq;

namespace AdventOfCode2020
{
    public class Password
    {
        public string Value { get; }
        public char KeyChar { get; }
        public uint MinOccurrence { get; }
        public uint MaxOccurrence { get; }

        public Password(string value, char keyChar, uint minOccurrence, uint maxOccurrence)
        {
            Value = value;
            KeyChar = keyChar;
            MinOccurrence = minOccurrence;
            MaxOccurrence = maxOccurrence;
        }

        public bool IsValid()
        {
            var occurrence = Value.Count(x => x == KeyChar);

            return occurrence >= MinOccurrence && occurrence <= MaxOccurrence;
        }

        public static Password FromLine(string line)
        {
            var spaceSeparated = line.Split(' ');

            var limits = spaceSeparated[0].Split('-');
            var minOccurrence = Convert.ToUInt32(limits[0]);
            var maxOccurrence = Convert.ToUInt32(limits[1]);

            var keyChar = spaceSeparated[1][0];

            var value = spaceSeparated[2];

            return new Password(value, keyChar, minOccurrence, maxOccurrence);
        }
    }
}