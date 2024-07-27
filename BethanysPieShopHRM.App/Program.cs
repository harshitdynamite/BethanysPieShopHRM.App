using BethanysPieShopHRM.App;
using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Registering the dependency using the DI container here
builder.Services.AddHttpClient<IEmployeeDataService,EmployeeDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Registering the ApplicationState class to access the application state.
//It is just like any other class
//You could have added it as SingleTon but it would have the same effect
builder.Services.AddScoped<ApplicationState>();
await builder.Build().RunAsync();
