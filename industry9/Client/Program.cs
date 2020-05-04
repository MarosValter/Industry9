using System;
using System.Net.Http;
using System.Threading.Tasks;
using industry9.Shared;
using industry9.Shared.Api;
using industry9.Shared.Authorization;
using industry9.Shared.Authorization.Implementation;
using industry9.UI;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
                config.AddPolicy(Policies.IsReadOnly, Policies.IsUserPolicy());
                // config.AddPolicy(Policies.IsMyDomain, Policies.IsMyDomainPolicy());  Only works on the server end
            });
            services.AddScoped<IdentityAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();
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

            //services.AddFluxor(options =>
            //{
            //    options.UseDependencyInjection(typeof(Startup).Assembly);
            //    options.AddMiddleware<Blazor.Fluxor.ReduxDevTools.ReduxDevToolsMiddleware>();
            //});
        }
    }
}
