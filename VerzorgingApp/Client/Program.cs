using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VerzorgingApp.Client.Services;

namespace VerzorgingApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("VerzorgingApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("VerzorgingApp.ServerAPI"));
            builder.Services.AddHttpClient<IElderDataService, ElderDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44327");
            });
           
            builder.Services.AddHttpClient<ICaretakerDataService, CaretakerDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44327");
            });

            builder.Services.AddHttpClient<ISupervisorDataService, SupervisorDataService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44327");
            });

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
