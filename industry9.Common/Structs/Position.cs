using System;
using HotChocolate.Language;

namespace industry9.Common.Structs
{
    public struct Position
    {
        public byte X { get; set; }
        public byte Y { get; set; }

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
                X = Convert.ToByte(parts[0]),
                Y = Convert.ToByte(parts[1]),
            };
        }
    }
}
