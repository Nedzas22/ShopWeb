using Microsoft.Extensions.Options;

namespace ShopWeb
{
    public class FruitMiddleware
    {
        private RequestDelegate _next;
        private FruitOptions _options;

        public FruitMiddleware(RequestDelegate next, IOptions<FruitOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/fruit")
            {
                await context.Response.WriteAsync($"Fruit Name: {_options.Name}, Color: {_options.Color}");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
