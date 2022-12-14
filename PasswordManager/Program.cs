using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PasswordManager;
using PasswordManager.Base;
using PasswordManager.Helpers;
using PasswordManager.Interfaces;
using PasswordManager.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


BaseApiInfo.ApiAddress = builder.Configuration["ApiAddress"];


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserClientService, UserClientService>();
builder.Services.AddScoped<ILoginClientService, LoginClientService>();
builder.Services.AddScoped<IPasswordClientService, PasswordClientService>();


//Add Authorize
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
//builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
//


//AddLocalStorage
builder.Services.AddBlazoredLocalStorage();
//

await builder.Build().RunAsync();
