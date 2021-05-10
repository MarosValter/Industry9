using GreenDonut;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Base
{
    public abstract class BaseNodeType<TDocument, TLoader> : BaseDocumentType<TDocument>
        where TDocument : IDocument
        where TLoader : IDataLoader
    {
        protected override void Configure(IObjectTypeDescriptor<TDocument> descriptor)
        {
            base.Configure(descriptor);
            descriptor.ImplementsNode()
                      .IdField(d => d.Id)
                      .ResolveNodeWith<TLoader>(l => l.LoadAsync(default(object)!, default));
        }
    }
}
