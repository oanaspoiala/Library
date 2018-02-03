using System;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using IMiddleware = Library.System.Libs.Interfaces.IMiddleware;

namespace Library.Services.Middleware
{
    public class LoggingMiddleware : IMiddleware
    {
        public RequestDelegate _next { get; set; }
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation(context.Request.GetUri().ToString());
            await _next(context);
        }
    }
}
