using HotChocolate.Types;

namespace industry9.GraphQL.UI.Position
{
    public class PositionInputType : InputObjectType<Common.Structs.Position>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Common.Structs.Position> descriptor)
        {
            descriptor.Name("PositionInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.X).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.Y).Type<NonNullType<IntType>>();
        }
    }
}
