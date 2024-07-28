using BethanysPieShopHRM.App;
using BethanysPieShopHRM.App.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Registering the dependency using the DI container here
builder.Services.AddHttpClient<IEmployeeDataService,EmployeeDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Registering the ApplicationState class to access the application state.
//It is just like any other class
//You could have added it as SingleTon but it would have the same effect
builder.Services.AddScoped<ApplicationState>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOidcAuthentication(options => {
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});
await builder.Build().RunAsync();
