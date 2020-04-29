//using HotChocolate.Types;
//using industry9.GraphQL.UI.Dashboard;

//namespace industry9.GraphQL.UI
//{
//    public class MutationType : ObjectType<DashboardMutations>
//    {
//        protected override void Configure(IObjectTypeDescriptor<DashboardMutations> descriptor)
//        {
//            descriptor.Name("Mutation");
//            descriptor.Field(m => m.CreateDashboard(default, default))
//                .Type<NonNullType<DashboardType>>()
//                .Argument("dashboard", a => a.Type<NonNullType<DashboardInputType>>());
//        }
//    }
//}
