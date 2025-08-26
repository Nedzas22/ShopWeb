using ShopWeb.Services;

namespace ShopWeb
{
    public class CustomEndpoint
    {
        public static async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            //IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "Custom ENDPOINT");
        }
    }
}
