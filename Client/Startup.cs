using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Services;
using CurrieTechnologies.Razor.Clipboard;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoDashboardBlazor.Client
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IWebAssemblyHostEnvironment env)
        {
            services.AddBlazoredModal();
            services.AddBlazoredToast();
            services.AddBlazorise(options => options.ChangeTextOnKeyPress = true)
                 .AddBootstrapProviders()
                 .AddFontAwesomeIcons();
            services.AddClipboard();
            services.AddBlazoredLocalStorage();
            services.AddSingleton(provider =>
            {
                var config = provider.GetService<IConfiguration>();
                return config?.GetSection(nameof(AppConfiguration)).Get<AppConfiguration>() ?? new AppConfiguration() { };
            });
            services.AddScoped(sp => new HttpClient { Timeout = new TimeSpan(2, 0, 0), BaseAddress = new Uri($"{env.BaseAddress}api/") });
            StartupShared.ConfigureSharedServices(services);
        }
    }
}