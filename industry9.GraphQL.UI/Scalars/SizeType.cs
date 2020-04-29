using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using HotChocolate.Language;
using HotChocolate.Types;

namespace industry9.GraphQL.UI.Scalars
{
    public class SizeType : ScalarType<Size>
    {
        public SizeType() : base("Size")
        {
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            return literal is ObjectValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is ObjectValueNode objectLiteral)
            {
                var heightValue = objectLiteral.Fields.FirstOrDefault(f => f.Name.Value == nameof(Size.Height).ToLowerInvariant())
                        ?? throw new ArgumentException("Object literal is missing Height field.", nameof(literal));
                var height = heightValue.Value is IntValueNode heightNode
                    ? heightNode.ToInt32()
                    : throw new ArgumentException("Field Height is not a IntValueNode.");

                var widthValue = objectLiteral.Fields.FirstOrDefault(f => f.Name.Value == nameof(Size.Width).ToLowerInvariant())
                             ?? throw new ArgumentException("Object literal is missing Width field.", nameof(literal));
                var width = widthValue.Value is IntValueNode widthNode
                    ? widthNode.ToInt32()
                    : throw new ArgumentException("Field Width is not a IntValueNode.");

                return new Size
                {
                    Height = height,
                    Width = width
                };
            }

            throw new ArgumentException(
                "The Size type can only parse object literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object value)
        {
            if (value is Size size)
            {
                var fields = new List<ObjectFieldNode>
                {
                    new ObjectFieldNode(nameof(Size.Height), size.Height),
                    new ObjectFieldNode(nameof(Size.Width), size.Width)
                };
                return new ObjectValueNode(fields);
            }

            throw new ArgumentException("The specified value has to be a Size.");
        }
    }
}
