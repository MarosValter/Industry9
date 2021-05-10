using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Base
{
    public abstract class BaseDocumentType<TDocument> : ObjectType<TDocument>
        where TDocument : IDocument
    {
        protected override void Configure(IObjectTypeDescriptor<TDocument> descriptor)
        {
            descriptor.Field(d => d.Id).Type<NonNullType<IdType>>();
            descriptor.Field(d => d.Created).Type<NonNullType<DateTimeType>>();
        }
    }
}
