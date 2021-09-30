using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Classes
{
    public static class WebAssemblyHostExtensions
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            string cultureString = await localStorage.GetItemAsync<string>("language");

            CultureInfo cultureInfo;

            if (!string.IsNullOrWhiteSpace(cultureString))
            {
                cultureInfo = new CultureInfo(cultureString);
            }
            else
            {
                cultureInfo = new CultureInfo("en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
