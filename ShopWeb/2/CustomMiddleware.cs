using ShopWeb.Services;

namespace ShopWeb
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IResponseFormatter formatter1, IResponseFormatter formatter2, IResponseFormatter formatter3)
        {
            if(context.Request.Path =="/middleware")
            {
                await formatter1.Format(context, String.Empty);
                await formatter2.Format(context, String.Empty);
                await formatter3.Format(context, String.Empty);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
