using LabWeb;
using LabWeb.DataStore;
using LabWeb.DataStore.Repositories;
using LabWeb.DataStore.Repositories.Contracts;
using LabWeb.Services;
using LabWeb.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //blazor serverside adding

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7236/") });

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IPeopleRepository, PeopleRepository>();
builder.Services.AddTransient<IPeopleService, PeopleService>();
builder.Services.AddTransient<IPeopleServiceServer, PeopleServiceServer>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers(); //blazor serverside adding

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
