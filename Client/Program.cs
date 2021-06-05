using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.JSInterop;
using Serilog;
using Serilog.Core;
using Serilog.Debugging;

namespace CryptoDashboardBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            SelfLog.Enable(m => Console.Error.WriteLine(m));

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            Startup.ConfigureServices(builder.Services, builder.HostEnvironment);

            var levelSwitch = new LoggingLevelSwitch();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                .CreateLogger();

            builder.Logging.AddSerilog();
            var host = builder.Build();

            await StartLocalization(host);
            await host.RunAsync();
        }

        private static async Task StartLocalization(WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
            if (result == null)
            {
                result = "de-DE";
            }
            var culture = CultureInfo.CreateSpecificCulture(result);
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            ValidatorOptions.Global.LanguageManager.Culture = culture;
        }
    }
}