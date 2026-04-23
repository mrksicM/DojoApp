using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;
using BlazorApp.Services;
using BlazorApp.Interfaces;
using BlazorApp.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ICrudService<Member>, MemberService>();
builder.Services.AddScoped<ICrudService<Organization>, OrganizationService>();
builder.Services.AddScoped<ICrudService<Dojo>, DojoService>();
builder.Services.AddScoped<IMembersService, MemberService>();
builder.Services.AddScoped<ToastService>();


builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("http://localhost:5210/") });

await builder.Build().RunAsync();
