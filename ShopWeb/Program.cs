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



var app = builder.Build();

app.MapControllers();

//app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");\

app.MapDefaultControllerRoute();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();
