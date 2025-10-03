using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopWeb;
using ShopWeb.Infrastucture;
using ShopWeb.Models;
using ShopWeb.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapControllers();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.UseStaticFiles();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
