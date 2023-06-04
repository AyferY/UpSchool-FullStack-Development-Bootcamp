using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UpStorage.Wasm;
using UpStorage.Domain.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var apiUrl = builder.Configuration.GetSection("ApiUrl").Value!;

var signalRUrl = builder.Configuration.GetSection("SignalRUrl").Value!;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

//builder.Services.AddLocalization(options =>
//{
//    options.ResourcesPath = "Resources";
//});


builder.Services.AddSingleton<IUrlHelperService>(new UrlHelperService(apiUrl,signalRUrl));


await builder.Build().RunAsync();
