using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Portfolio.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
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
