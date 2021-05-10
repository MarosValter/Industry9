using System;
using System.Drawing;
using HotChocolate.Language;
using HotChocolate.Types;

namespace industry9.GraphQL.UI.Scalars
{
    public class PositionType : ScalarType<Point, StringValueNode>
    {
        public PositionType() : base("Position")
        {
        }

        protected override Point ParseLiteral(StringValueNode valueSyntax)
        {
            var parts = valueSyntax.Value.Split(',');
            return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        protected override StringValueNode ParseValue(Point runtimeValue)
        {
            return new StringValueNode($"{runtimeValue.X},{runtimeValue.Y}");
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            if (resultValue is Point position)
            {
                return ParseValue(position);
            }

            throw new ArgumentException("The specified value has to be a Point.");
        }
    }
}
