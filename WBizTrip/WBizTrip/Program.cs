global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WBizTrip.Client;
using WBizTrip.Client.Authentication;
using WBizTrip.Client.Services;
using WBizTrip.Client.Services.Abstractions;
using WBizTrip.Domain.Enums;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7001/api/")
    });

builder.Services.AddScoped<ITeamLeaderService, TeamLeaderService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripSuggestionService, TripSuggestionService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();

