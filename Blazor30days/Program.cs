using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor30days.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor30days
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<Day23SampleModel>();
            builder.Services.AddSingleton(provider =>
            {
                var config = provider.GetService<IConfiguration>();
                return config.GetSection("test").Get<TestConfig>();
            });

            // read JSON file as a stream for configuration
            var client = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            // the appsettings file must be in 'wwwroot'
            using var response = await client.GetAsync("mysettings.json");
            using var stream = await response.Content.ReadAsStreamAsync();
            builder.Configuration.AddJsonStream(stream);

            await builder.Build().RunAsync();
        }
    }
}