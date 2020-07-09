using System;
using System.Drawing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo;
using Fluxor;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using industry9.Common.Enums;
using industry9.Common.GraphQL;
using industry9.Common.Structs;
using industry9.DataModel.UI.Data;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.DataModel.UI.Repositories.Widget;
using industry9.DataModel.UI.Serializers;
using industry9.DataModel.UI.Services;
using industry9.DataSource.GraphQL;
using industry9.DataSource.PropertiesData;
using industry9.GraphQL.UI.Dashboard;
using industry9.GraphQL.UI.Data;
using industry9.GraphQL.UI.DataSourceDefinition;
using industry9.GraphQL.UI.Scalars;
using industry9.GraphQL.UI.Widget;
using industry9.Server.Data;
using industry9.Server.Identity;
using industry9.Server.Services;
using industry9.Shared.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using WidgetType = industry9.GraphQL.UI.Widget.WidgetType;

namespace industry9.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public string MongoConnectionString => Configuration.GetConnectionString("MongoDB");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            BsonSerializer.RegisterSerializer(new ColorSerializer());
            BsonSerializer.RegisterSerializer(new SizeSerializer());
            BsonSerializer.RegisterSerializer(new PositionSerializer());

            BsonClassMap.RegisterClassMap<RandomDataSourceProperties>();
            BsonClassMap.RegisterClassMap<DataQueryDataSourceProperties>();

            services.AddSingleton<IMongoClient>(new MongoClient(MongoConnectionString));
            services.AddSingleton(s => s.GetRequiredService<IMongoClient>().GetDatabase("industry9"));

            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<DashboardDocument>("Dashboards"));
            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<WidgetDocument>("Widgets"));
            services.AddSingleton(s => s.GetRequiredService<IMongoDatabase>().GetCollection<DataSourceDefinitionDocument>("DataSourceDefinitions"));

            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IWidgetRepository, WidgetRepository>();
            services.AddScoped<IDataSourceDefinitionRepository, DataSourceDefinitionRepository>();

            services.AddTransient<ISchemaExtender, DataSourceSchemaExtender>();
            services.AddSingleton<IDataSourcePropertiesService, DataSourcePropertiesService>();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();
            //services.AddGraphQLSubscriptions();
            services.AddInMemorySubscriptionProvider();

            services.AddGraphQL(sp =>
            {
                var propService = sp.GetService<IDataSourcePropertiesService>();
                propService.ScanForProperties(new [] {typeof(RandomDataSourceProperties).Assembly});
                var extenders = sp.GetServices<ISchemaExtender>();
                var builder = SchemaBuilder.New()
                    .AddServices(sp)
                    .BindClrType<Color, ColorType>()
                    .BindClrType<Position, PositionType>()
                    .BindClrType<Size, SizeType>()
                    .BindClrType<DateTime, DateTimeType>()
                    .AddQueryType(d => d.Name("Query"))
                    .AddType<DashboardQueries>()
                    .AddType<WidgetQueries>()
                    .AddType<DataSourceDefinitionQueries>()
                    .AddMutationType(d => d.Name("Mutation"))
                    .AddType<DashboardMutations>()
                    .AddType<WidgetMutations>()
                    .AddType<DataSourceDefinitionMutations>()
                    .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddType<DataSubscriptions>()

                    // Types
                    .AddType<DashboardType>()
                    .AddType<WidgetType>()
                    .AddType<DataSourceDefinitionType>()
                    //.AddType<IDataSourceProperties>()
                    .AddType<LabelData>()
                    .AddType<SensorData>()
                    .AddType<ColumnMappingData>()
                    //.AddType<TimeSettings>()
                    //.AddType<RelativeTimeSettings>()
                    //.AddType<AbsoluteTimeSettings>()

                    // Input types
                    .AddType<DashboardInputType>()
                    .AddType<WidgetInputType>()
                    .AddType<DataSourceDefinitionInputType>()
                    //.AddInputObjectType<IDataSourceProperties>()
                    .AddInputObjectType<LabelData>()
                    .AddInputObjectType<ColumnMappingData>()
                    //.AddInputObjectType<TimeSettings>()
                    //.AddInputObjectType<RelativeTimeSettings>()
                    //.AddInputObjectType<AbsoluteTimeSettings>()

                    // Enums
                    .AddEnumType<RelativeTimeMode>();

                //foreach (var extender in extenders)
                //{
                //    extender.Extend(builder);
                //}

                foreach (var type in propService.Types)
                {
                    builder.AddType(type);

                    var t = typeof(InputObjectType<>).MakeGenericType(type);
                    var o = Activator.CreateInstance(t);
                    builder.AddType((INamedType)o);
                }
                return builder.Create();
            });

            //Add Policies / Claims / Authorization - https://stormpath.com/blog/tutorial-policy-based-authorization-asp-net-core
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
                options.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
                options.AddPolicy(Policies.IsReadOnly, Policies.IsReadOnlyPolicy());
                //options.AddPolicy(Policies.IsMyDomain, Policies.IsMyDomainPolicy());  // valid only on serverside operations
            });

            services.AddIdentityMongoDbProvider<ApplicationUser, ApplicationRole>(identity =>
                {
                    // Password settings
                    identity.Password.RequireDigit = false;
                    identity.Password.RequireLowercase = false;
                    identity.Password.RequireNonAlphanumeric = false;
                    identity.Password.RequireUppercase = false;
                    identity.Password.RequiredLength = 1;
                    identity.Password.RequiredUniqueChars = 0;

                    // Lockout settings
                    //identity.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    //identity.Lockout.MaxFailedAccessAttempts = 10;
                    //identity.Lockout.AllowedForNewUsers = true;

                    // Require Confirmed Email User settings
                    if (Convert.ToBoolean(Configuration["industry9:RequireConfirmedEmail"] ?? "false"))
                    {
                        identity.User.RequireUniqueEmail = false;
                        identity.SignIn.RequireConfirmedEmail = true;
                    }
                }, db => { db.ConnectionString = MongoConnectionString; })
                .AddDefaultTokenProviders();

            var authBuilder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            if (Convert.ToBoolean(Configuration["ExternalAuthProviders:Google:Enabled"] ?? "false"))
            {
                authBuilder.AddGoogle(options =>
                {
                    options.SignInScheme = GoogleDefaults.AuthenticationScheme;

                    options.ClientId = Configuration["ExternalAuthProviders:Google:ClientId"];
                    options.ClientSecret = Configuration["ExternalAuthProviders:Google:ClientSecret"];
                });
            }

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureExternalCookie(options =>
            {
                // macOS login fix
                options.Cookie.SameSite = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // macOS login fix
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.HttpOnly = false;

                // Suppress redirect on API URLs in ASP.NET Core -> https://stackoverflow.com/a/56384729/54159
                options.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToAccessDenied = context =>
                    {
                        if (context.Request.Path.StartsWithSegments("/api"))
                        {
                            context.Response.StatusCode = (int)(HttpStatusCode.Unauthorized);
                        }

                        return Task.CompletedTask;
                    },
                    OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "industr9 API", Version = "v1" });
            });

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
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var databaseInitializer = serviceScope.ServiceProvider.GetService<IDatabaseInitializer>();
                databaseInitializer.SeedAsync().Wait();
            }

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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWebSockets();
            app.UseGraphQL("/graphql");
            app.UsePlayground("/graphql");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "industry9 API V1");
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index_blazor.html");
            });
        }
    }
}
