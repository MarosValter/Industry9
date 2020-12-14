using System;
using HotChocolate.Language;

namespace industry9.Common.Structs
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public static Position FromString(string value)
        {
            var parts = value.Trim().Split(',');
            if (parts.Length != 2)
            {
                throw new InvalidFormatException("Value is not in valid format.");
            }

            return new Position
            {
                X = Convert.ToInt32(parts[0]),
                Y = Convert.ToInt32(parts[1]),
            };
        }
    }
}
