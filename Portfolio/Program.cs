using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Classes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Portfolio
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            builder.Services.AddScoped(sp => httpClient);
            builder.Services.AddLocalization();
            builder.Services.AddBlazoredLocalStorage();

            var host = builder.Build();
            await host.SetDefaultCulture();
            await DataManager.FetchPostsAsync(httpClient);
            await host.RunAsync();
        }
    }
}
