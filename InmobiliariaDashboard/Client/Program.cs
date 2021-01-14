using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using InmobiliariaDashboard.Client.Pages.Enterprise;

namespace InmobiliariaDashboard.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.Scan(sc =>
                sc.FromCallingAssembly()
                    .FromAssemblies(typeof(IService).Assembly)
                    .AddClasses()
                    .AsImplementedInterfaces());

            var cultureInfo = new CultureInfo("es-MX") {NumberFormat = {CurrencySymbol = "$"}};
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            await builder.Build().RunAsync();
        }
    }
}