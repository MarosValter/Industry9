using HotChocolate.Types;

namespace industry9.GraphQL.UI.Size
{
    public class SizeInputType : InputObjectType<System.Drawing.Size>
    {
        protected override void Configure(IInputObjectTypeDescriptor<System.Drawing.Size> descriptor)
        {
            descriptor.Name("SizeInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Width).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.Height).Type<NonNullType<IntType>>();
        }
    }
}
