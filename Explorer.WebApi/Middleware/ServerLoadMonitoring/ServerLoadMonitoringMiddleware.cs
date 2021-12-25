namespace Explorer.WebApi.Middleware.ServerLoadMonitoring
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public class ServerLoadMonitoringMiddleware
    {
        private static DateTime currentDate;
        private static int requestsPerMinute;
        private static int requestLimit;
        private readonly RequestDelegate next;

        public ServerLoadMonitoringMiddleware(
            RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            requestLimit = Convert.ToInt32(configuration["RequestsLimit"]);
        }

        public async Task Invoke(HttpContext context)
        {
            if (currentDate.Minute != DateTime.Now.Minute)
            {
                currentDate = DateTime.Now;
                requestsPerMinute = 0;
            }

            if (++requestsPerMinute == requestLimit)
            {
                Log.Warning("The safe load is exceeded. Many requests per minute");
            }

            await this.next(context);
        }
    }
}