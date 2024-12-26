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
builder.Services.AddScoped<DbTrainning>();
builder.Services.AddScoped<DbTrainningDay>();
builder.Services.AddScoped<DbTrainningExercise>();
builder.Services.AddScoped<DbUsers>();
builder.Services.AddScoped<OrdenationService>();

//builder.Services.AddSingleton<UsersDb>();
//builder.Services.AddSingleton<DbMusclesAndExercises>();
//builder.Services.AddSingleton<DbTrainning>();
//builder.Services.AddSingleton<DbTrainningDay>();
//builder.Services.AddSingleton<DbTrainningExercise>();
//builder.Services.AddSingleton<DbUsers>();



await builder.Build().RunAsync();
