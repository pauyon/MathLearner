global using Microsoft.AspNetCore.Components.Authorization;
using MathLearner.Domain.Entities;
using MathLearnerWasmApp;
using MathLearnerWasmApp.Services;
using MathLearnerWasmApp.Services.QuizService;
using MathLearnerWasmApp.Services.RoleService;
using MathLearnerWasmApp.Services.UserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseApiUrl")) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IService<User>, UserService>();
builder.Services.AddScoped<IService<Role>, RoleService>();
builder.Services.AddScoped<IService<Quiz>, QuizService>();
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();
