using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pizzaria.WEB;
using Pizzaria.WEB.Services;
using Pizzaria.WEB.Services.ErrorsServices;
using Pizzaria.WEB.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IErroHandleService, ErrorHandlerService>();

await builder.Build().RunAsync();
