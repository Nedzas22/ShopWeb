using Microsoft.Extensions.Options;
using ShopWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(options =>
{
    options.Name = "watermelon";
    options.Color = "red";
});

var app = builder.Build();

app.MapGet("/fruit", async(HttpContext context, IOptions<FruitOptions> FruitOptions) => 
{
    FruitOptions options = FruitOptions.Value;
    await context.Response.WriteAsync($"Fruit Name: {options.Name}, Color: {options.Color}");
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
