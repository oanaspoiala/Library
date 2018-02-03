using System;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using IMiddleware = Library.System.Libs.Interfaces.IMiddleware;

namespace Library.Services.Middleware
{
    public class AuthMiddleware : IMiddleware
    {
        public RequestDelegate _next { get; set; }
        private readonly ILogger _logger;

        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(context.Request.GetUri().ToString());

            if (string.Compare(context.Request.GetUri().Segments[1], "swagger/", StringComparison.OrdinalIgnoreCase) == 0)
            {
                await _next(context);
                return;
            }

            //if (!context.Request.Headers.ContainsKey("Authorization"))
            //{
            //    context.Response.StatusCode = 401; //UnAuthorized
            //    await context.Response.WriteAsync("Missing authorization header");
            //    return;
            //}



            await _next(context);
        }
    }
}
