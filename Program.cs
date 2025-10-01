// File: Program.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 30, 2024 8:37AM
// Date File Created: Sep 30, 2024 8:37AM
// Version: 0.0.0.0000

// You�re using .NET 8 �Blazor Web App� template.
// ? Your app supports interactive Blazor Server components.
// ? It does not support Blazor WebAssembly interactivity.
// ? It does not support static -only updates(because those don�t re - render).

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorResume.Codes;

namespace BlazorResume
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            builder.Services.AddSingleton<LogService>();
            builder.Services.AddSingleton<SearchService>();
            builder.Services.AddSingleton<LayoutState>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}