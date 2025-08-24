using ShopWeb.Services;

namespace ShopWeb
{
    public class CustomMiddleware2
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;

        public CustomMiddleware2(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path =="/middleware2")
            {
                await _formatter.Format(context, "Custom middleware");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
