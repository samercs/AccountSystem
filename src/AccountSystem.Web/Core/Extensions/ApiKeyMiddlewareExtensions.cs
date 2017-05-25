using Microsoft.AspNetCore.Builder;
using AccountSystem.Web.Core.Middleware;

namespace AccountSystem.Web.Core.Extensions
{
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ApiKeyMiddleware>();
            return builder;
        }
    }
}
