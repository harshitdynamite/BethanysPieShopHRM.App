using BethanysPieShopHRM.App;
using BethanysPieShopHRM.App.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//Registering the dependency using the DI container here
builder.Services.AddHttpClient<IEmployeeDataService,EmployeeDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
//adding BaseAddressAuthorizationMessageHandler as messagehandler as this will attach the token for us automatically to the request made to application base uri
//as this base uri is the one hosting the controller
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Registering the ApplicationState class to access the application state.
//It is just like any other class
//You could have added it as SingleTon but it would have the same effect
builder.Services.AddScoped<ApplicationState>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOidcAuthentication(options => {
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});
await builder.Build().RunAsync();
