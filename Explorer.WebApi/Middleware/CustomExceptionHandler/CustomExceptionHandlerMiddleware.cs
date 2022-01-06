namespace Explorer.WebApi.Middleware.CustomExceptionHandler
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FluentValidation;
    using Microsoft.AspNetCore.Http;

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            this.next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception exception)
            {
                await this.HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case DirectoryNotFoundException directoryNotFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(directoryNotFoundException.Message);
                    break;
                case FileNotFoundException fileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(fileNotFoundException.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}