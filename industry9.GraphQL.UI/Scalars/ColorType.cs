using System;
using System.Drawing;
using HotChocolate.Language;
using HotChocolate.Types;

namespace industry9.GraphQL.UI.Scalars
{
    public class ColorType : ScalarType<Color>
    {
        public ColorType() : base("Color")
        {
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            return literal is StringValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is StringValueNode stringLiteral)
            {
                return Color.FromName(stringLiteral.Value);
            }

            throw new ArgumentException(
                "The Color type can only parse string literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object value)
        {
            if (value is Color color)
            {
                return new StringValueNode(null, color.ToString(), false);
            }

            throw new ArgumentException("The specified value has to be a Color.");
        }
    }
}
