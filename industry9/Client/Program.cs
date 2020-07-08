using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared;
using industry9.Shared.Api;
using industry9.Shared.Authorization;
using industry9.Shared.Authorization.Implementation;
using industry9.Shared.GraphQL.Serializers;
using industry9.Shared.Middleware;
using industry9.Shared.Navigation;
using industry9.Shared.Store.UserProfile;
using industry9.UI;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;
using StrawberryShake.Transport.WebSockets;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace industry9.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureServices(builder.Services, builder.HostEnvironment);

            var host = builder.Build();
            host.UseLoadingBar();

            await host.RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services, IWebAssemblyHostEnvironment environment)
        {
            services.AddSingleton(new HttpClient { BaseAddress = new Uri(environment.BaseAddress) });
            services.AddAuthorizationCore(config =>
            {
                config.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
                config.AddPolicy(Policies.IsUser, Policies.IsUserPolicy());
                config.AddPolicy(Policies.IsReadOnly, Policies.IsReadOnlyPolicy());
                // config.AddPolicy(Policies.IsMyDomain, Policies.IsMyDomainPolicy());  Only works on the server end
            });
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<IdentityAuthenticationStateProvider>());
            services.AddScoped<IAuthorizeApi, AuthorizeApi>();
            services.AddScoped<IUserProfileApi, UserProfileApi>();
            services.AddLoadingBar();
            services.AddScoped<AppState>();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            services.AddHttpClient("industry9Client", c => c.BaseAddress = new Uri(new Uri(environment.BaseAddress), "graphql"));
            services.AddWebSocketClient("industry9Client", (sp, c) => c.Uri = new UriBuilder(new Uri(environment.BaseAddress)) { Scheme = "wss", Path = "graphql" }.Uri);
            services.Addindustry9Client();
            services.AddSingleton<industry9NavigationManager>();

            services.AddSingleton<IValueSerializer, ColorSerializer>();
            services.AddSingleton<IValueSerializer, PositionValueSerializer>();

            services.AddFluxor(opt =>
            {
                opt.ScanAssemblies(typeof(UserProfileState).Assembly);
                opt.AddMiddleware<HistoryMiddleware>();
            });
        }
    }
}
