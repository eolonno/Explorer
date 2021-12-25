namespace Explorer.WebApi.Middleware.ServerLoadMonitoring
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public static class ServerLoadMonitoringMiddlewareExtension
    {
        public static IApplicationBuilder UseServerLoadMonitoring(
            this IApplicationBuilder builder, IConfiguration configuration) =>
                builder.UseMiddleware<ServerLoadMonitoringMiddleware>(configuration);
    }
}