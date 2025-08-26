using ShopWeb.Services;

namespace ShopWeb
{
    public class GuidService : IResponseFormatter
    {
        private Guid _guid = Guid.NewGuid();
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.WriteAsync($"GuidResponse{_guid}\n <h2> {content}</h2>");
        }
    }
}
