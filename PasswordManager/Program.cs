using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PasswordManager;
using PasswordManager.Base;
using PasswordManager.Interfaces;
using PasswordManager.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


BaseApiInfo.ApiAddress = builder.Configuration["ApiAddress"];


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserClientService, UserClientService>();

await builder.Build().RunAsync();
