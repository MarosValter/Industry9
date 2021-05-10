using System;
using System.Drawing;
using HotChocolate.Language;
using HotChocolate.Types;

namespace industry9.GraphQL.UI.Scalars
{
    public class SizeType : ScalarType<Size, StringValueNode>
    {
        public SizeType() : base("Size")
        {
        }

        protected override Size ParseLiteral(StringValueNode valueSyntax)
        {
            var parts = valueSyntax.Value.Split(',');
            return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        protected override StringValueNode ParseValue(Size runtimeValue)
        {
            return new StringValueNode($"{runtimeValue.Height},{runtimeValue.Width}");
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            if (resultValue is Size size)
            {
                return ParseValue(size);
            }

            throw new ArgumentException("The specified value has to be a Size.");
        }
    }
}
