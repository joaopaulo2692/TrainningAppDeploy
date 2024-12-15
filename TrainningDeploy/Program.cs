using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TrainningApp.Core.Entities;
using TrainningDeploy;
using TrainningDeploy.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<UsersDb>();
builder.Services.AddScoped<DbMusclesAndExercises>();
builder.Services.AddScoped<OrdenationService>();



await builder.Build().RunAsync();
