using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using ShopWeb.Services;

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

        public async Task InvokeAsync(HttpContext context, ILogger<FruitMiddleware> logger)
        {
            if (context.Request.Path == "/fruit")
            {
               logger.LogDebug($"Started processing for {context.Request.Path}");
               await context.Response.WriteAsync($"{_options.Name} is {_options.Color}\n");
               logger.LogDebug($"End processing for {context.Request.Path}");
            }
            else
            {
                await _next(context);
                logger.LogDebug($"fruit not requestest processing for {context.Request.Path}");
            }
            logger.LogDebug($"fruit was or was requestest processing for {context.Request.Path}");
        }
    }
}
