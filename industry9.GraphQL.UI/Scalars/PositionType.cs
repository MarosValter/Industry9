using System;
using System.Collections.Generic;
using System.Linq;
using HotChocolate.Language;
using HotChocolate.Types;
using industry9.Common.Structs;

namespace industry9.GraphQL.UI.Scalars
{
    public class PositionType : ScalarType<Position>
    {
        public PositionType() : base("Position")
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
                var xValue = objectLiteral.Fields.FirstOrDefault(f => f.Name.Value == nameof(Position.X))
                        ?? throw new ArgumentException("Object literal is missing X field.", nameof(literal));
                var x = xValue.Value is IntValueNode xNode
                    ? xNode.ToByte()
                    : throw new ArgumentException("Field X is not a IntValueNode.");

                var yValue = objectLiteral.Fields.FirstOrDefault(f => f.Name.Value == nameof(Position.Y))
                             ?? throw new ArgumentException("Object literal is missing Y field.", nameof(literal));
                var y = yValue.Value is IntValueNode yNode
                    ? yNode.ToByte()
                    : throw new ArgumentException("Field Y is not a IntValueNode.");

                return new Position
                {
                    X = x,
                    Y = y
                };
            }

            throw new ArgumentException("The Position type can only parse object literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object value)
        {
            if (value is Position position)
            {
                var fields = new List<ObjectFieldNode>
                {
                    new ObjectFieldNode(nameof(Position.X), position.X),
                    new ObjectFieldNode(nameof(Position.Y), position.Y)
                };
                return new ObjectValueNode(fields);
            }

            throw new ArgumentException("The specified value has to be a Position.");
        }
    }
}
