using System.Drawing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore;
using industry9.Common.Enums;
using industry9.Common.Structs;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.DataModel.UI.Repositories.Widget;
using industry9.DataModel.UI.Serializers;
using industry9.GraphQL.UI.Dashboard;
using industry9.GraphQL.UI.DataSourceDefinition;
using industry9.GraphQL.UI.Scalars;
using industry9.GraphQL.UI.Widget;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace industry9.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            BsonSerializer.RegisterSerializer(new ColorSerializer());
            BsonSerializer.RegisterSerializer(new SizeSerializer());
            BsonSerializer.RegisterSerializer(new PositionSerializer());

            services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:27017"));
            services.AddSingleton(s => s.GetRequiredService<IMongoClient>().GetDatabase("industry9"));

            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<DashboardDocument>("Dashboards"));
            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<WidgetDocument>("Widgets"));
            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<DataSourceDefinitionDocument>("DataSourceDefinitions"));

            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IWidgetRepository, WidgetRepository>();
            services.AddScoped<IDataSourceDefinitionRepository, DataSourceDefinitionRepository>();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            services.AddGraphQL(sp =>
                SchemaBuilder.New()
                    .AddServices(sp)
                    .BindClrType<ObjectId, ObjectIdType>()
                    .BindClrType<Color, ColorType>()
                    .BindClrType<Position, PositionType>()
                    .BindClrType<Size, SizeType>()

                    .AddQueryType(d => d.Name("Query"))
                    .AddMutationType(d => d.Name("Mutation"))
                    //.AddSubscriptionType(d => d.Name("Subscription"))

                    .AddType<DashboardQueries>()
                    .AddType<WidgetQueries>()

                    .AddType<DashboardMutations>()
                    .AddType<WidgetMutations>()

                    .AddType<DashboardType>()
                    .AddType<WidgetType>()
                    .AddType<DataSourceDefinitionType>()
                    .AddType<LabelData>()
                    .AddType<ColumnMappingData>()
                    //.AddType<TimeSettings>()
                    //.AddType<RelativeTimeSettings>()
                    //.AddType<AbsoluteTimeSettings>()

                    .AddType<DashboardInputType>()
                    .AddType<WidgetInputType>()
                    .AddType<DataSourceDefinitionInputType>()
                    .AddInputObjectType<LabelData>()
                    .AddInputObjectType<ColumnMappingData>()
                    //.AddInputObjectType<TimeSettings>()
                    //.AddInputObjectType<RelativeTimeSettings>()
                    //.AddInputObjectType<AbsoluteTimeSettings>()

                    .AddEnumType<RelativeTimeMode>()
                    .Create()
                );

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.AllowTrailingCommas = true;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphQL();
            app.UsePlayground();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index_blazor.html");
                //endpoints.MapDefaultControllerRoute();
                //endpoints.MapFallbackToClientSideBlazor<Client.Program>("index_blazor.html");
            });
        }
    }
}
