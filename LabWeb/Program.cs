using LabWeb;
using LabWeb.Authentication;
using LabWeb.DataStore;
using LabWeb.DataStore.Repositories;
using LabWeb.DataStore.Repositories.Contracts;
using LabWeb.Services;
using LabWeb.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //blazor serverside adding
builder.Services.AddAuthenticationCore(); //blazor  authentication

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<HttpClient>(); // added to allow httpclient request and response
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IPeopleRepository, PeopleRepository>();
builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddTransient<IPeopleServiceServer, PeopleServiceServer>();
builder.Services.AddTransient<IPeopleService, PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7236", "https://localhost:7236")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    );

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); //blazor serverside adding

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
