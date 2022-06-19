using ASquaredRonWASM;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Net;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

if(builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5011") });
}
else if(builder.HostEnvironment.IsProduction())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://asquaredron.net") });
}

builder.Services.AddMudServices();
await builder.Build().RunAsync();