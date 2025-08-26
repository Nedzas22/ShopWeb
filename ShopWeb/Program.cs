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

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.MapGet("/", () => "Hello World!");

app.Run();
