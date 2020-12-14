using HotChocolate.Types;

namespace industry9.GraphQL.UI.Position
{
    public class PositionType : ObjectType<Common.Structs.Position>
    {
        protected override void Configure(IObjectTypeDescriptor<Common.Structs.Position> descriptor)
        {
            descriptor.Name("Position");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.X).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.Y).Type<NonNullType<IntType>>();
        }
    }
}
