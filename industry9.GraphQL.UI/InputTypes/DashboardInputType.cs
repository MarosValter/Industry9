﻿using System.Linq;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.InputTypes
{
    public class DashboardInputType : InputObjectType<DashboardDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DashboardDocument> descriptor)
        {
            descriptor.Name("DashboardInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Id).Type<IdType>();
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Private).Type<NonNullType<BooleanType>>();
            descriptor.Field(d => d.ColumnCount).Type<NonNullType<IntType>>();
            descriptor.Field(d => d.Labels).DefaultValue(Enumerable.Empty<LabelData>().ToList());
            descriptor.Field(d => d.Widgets).DefaultValue(Enumerable.Empty<DashboardWidgetData>().ToList());
        }
    }
}
