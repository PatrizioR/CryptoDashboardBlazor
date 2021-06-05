using System.Reflection;
using CryptoDashboardBlazor.Data.Repositories;
using Fluxor;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoDashboardBlazor.Data.Services
{
    public static class StartupShared
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static void ConfigureSharedServices(IServiceCollection services)
        {
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(StateFacade)));
                options.UseReduxDevTools();
            });
            services.AddScoped<StateFacade>();
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddLocalization();
        }
    }
}