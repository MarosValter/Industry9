using HotChocolate;

namespace industry9.Common.GraphQL
{
    public interface ISchemaExtender
    {
        void Extend(ISchemaBuilder builder);
    }
}
