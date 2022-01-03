namespace Explorer.WebApi.Middleware.FluentPath
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class FluentPathMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string controller;

        public FluentPathMiddleware(RequestDelegate next, string forController)
        {
            this.next = next;
            this.controller = forController;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value;
            var servicePartOfPath = $@"/api/{this.controller}/";

            if (Regex.IsMatch(path, $@"{servicePartOfPath}\w+"))
            {
                path = string.Join(
                        string.Empty, path.Skip(servicePartOfPath.Length))
                    .Replace("/", "%2F");

                context.Request.Path = new PathString(servicePartOfPath + path);
            }

            await this.next(context);
        }
    }
}