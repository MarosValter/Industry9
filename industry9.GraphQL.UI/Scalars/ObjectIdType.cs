using System;
using HotChocolate.Language;
using HotChocolate.Types;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Scalars
{
    public class ObjectIdType : ScalarType<ObjectId>
    {
        public ObjectIdType() : base("ObjectId")
        {
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            return literal is StringValueNode || literal is NullValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is NullValueNode)
            {
                return null;
            }

            if (literal is StringValueNode stringLiteral)
            {
                return ObjectId.TryParse(stringLiteral.Value, out var id)
                    ? id
                    : throw new ArgumentException(
                        $"Unable to parse '{stringLiteral.Value}' into ObjectId.",
                        nameof(literal));
            }

            throw new ArgumentException(
                "The ObjectId type can only parse string literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object value)
        {
            if (value == null)
            {
                return new NullValueNode(null);
            }

            if (value is ObjectId id)
            {
                return new StringValueNode(null, id.ToString(), false);
            }

            throw new ArgumentException("The specified value has to be a ObjectId.");
        }
    }
}
