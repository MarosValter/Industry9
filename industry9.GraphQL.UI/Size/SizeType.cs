using HotChocolate.Types;

namespace industry9.GraphQL.UI.Size
{
    public class SizeType : ObjectType<System.Drawing.Size>
    {
        protected override void Configure(IObjectTypeDescriptor<System.Drawing.Size> descriptor)
        {
            descriptor.Name("Size");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Width).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.Height).Type<NonNullType<IntType>>();
        }
    }
}
