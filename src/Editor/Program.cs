using CatCMS;
using CatCMS.Components;
using CatCMS.Components.Logics;
using CatCMS.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddDataProtection();
builder.Services.AddAuthorizationCore(options =>
{

});

builder.Services.AddScoped<IAccountManagement, AccountManagement>();
builder.Services.AddSingleton<CustomAuthStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<UserStatePublisherService>();

//builder.Services.AddHttpClient<AccountManagement>((sp, client) =>
//{
//    var jwtData = string.Empty;

//    var dataProtector = sp.GetDataProtector("auth");

//    var jwtToken = dataProtector.Unprotect(jwtData);

//    client.DefaultRequestHeaders.Add("Authorization", $"bearer {jwtToken}");
//});

builder.Services
    .AddHttpClient("WebAPI", client => client.BaseAddress = new Uri("https://api.contoso.com/v1.0"))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("WebAPI"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app = builder.Build();


await builder.Build().RunAsync();
