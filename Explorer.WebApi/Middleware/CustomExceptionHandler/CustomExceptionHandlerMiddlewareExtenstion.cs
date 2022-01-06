namespace Explorer.WebApi.Middleware.CustomExceptionHandler
{
    using Microsoft.AspNetCore.Builder;

    public static class CustomExceptionHandlerMiddlewareExtenstion
    {
        public static IApplicationBuilder UseCustomExceptionHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}