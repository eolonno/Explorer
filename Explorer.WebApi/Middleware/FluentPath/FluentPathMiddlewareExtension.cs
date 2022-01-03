namespace Explorer.WebApi.Middleware.FluentPath
{
    using Microsoft.AspNetCore.Builder;

    public static class FluentPathMiddlewareExtension
    {
        public static IApplicationBuilder UseFluentPath(
            this IApplicationBuilder builder, string forController) =>
            builder.UseMiddleware<FluentPathMiddleware>(forController);
    }
}