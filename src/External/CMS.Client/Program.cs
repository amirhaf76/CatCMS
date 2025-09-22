using CMS.Client.Components;
using CMS.Client.Components.Logics;
using CMS.Client.Services;
using CMS.Client.Services.Abstraction;
using CMS.Infrastructure.GeneratedAPIs.CMSAPI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services
    .AddHttpClient("WebAPI", client => client.BaseAddress = new Uri("https://localhost:7077"));

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("WebAPI"));
builder.Services.AddTransient<AuthenticationClient>(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = clientFactory.CreateClient("WebAPI");

    return new AuthenticationClient(client);
});
builder.Services.AddTransient<IAuthenticationClient, AuthenticationClient>();
builder.Services.AddTransient<IAccountManagement, TestAccountManagement>();
builder.Services.AddSingleton<CustomAuthStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(sp =>sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddSingleton<UserStatePublisherService>();



await builder.Build().RunAsync();
