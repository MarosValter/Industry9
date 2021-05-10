using System;
using System.Drawing;
using HotChocolate.Language;
using HotChocolate.Types;

namespace industry9.GraphQL.UI.Scalars
{
    public class ColorType : ScalarType<Color, StringValueNode>
    {
        public ColorType() : base("Color")
        {
        }

        protected override Color ParseLiteral(StringValueNode valueSyntax)
        {
            return Color.FromName(valueSyntax.Value);
        }

        protected override StringValueNode ParseValue(Color runtimeValue)
        {
            return new StringValueNode(runtimeValue.ToString());
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            if (resultValue is Color color)
            {
                return ParseValue(color);
            }

            throw new ArgumentException("The specified value has to be a Color.");
        }
    }
}
