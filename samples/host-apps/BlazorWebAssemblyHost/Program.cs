using BlazorWebAssemblyHost;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AnywhereUI.Blazor;
using AnywhereUI.SkiaVisualFramework.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

BlazorHostFramework.Init(new BlazorSkiaVisualFramework());

await builder.Build().RunAsync();
