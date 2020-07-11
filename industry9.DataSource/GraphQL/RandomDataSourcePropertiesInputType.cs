//using HotChocolate.Types;
//using industry9.DataSource.PropertiesData;

//namespace industry9.DataSource.GraphQL
//{
//    public class RandomDataSourcePropertiesInputType : InputObjectType<RandomDataSourceProperties>
//    {
//        protected override void Configure(IInputObjectTypeDescriptor<RandomDataSourceProperties> descriptor)
//        {
//            base.Configure(descriptor);

//            descriptor.Name("RandomDataSourcePropertiesInput");
//            descriptor.BindFieldsExplicitly();
//            descriptor.Field(d => d.Min);
//            descriptor.Field(d => d.Max);
//        }
//    }
//}
