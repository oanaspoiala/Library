using System;
using System.Threading.Tasks;
using Library.System.Extensions;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using IMiddleware = Library.System.Libs.Interfaces.IMiddleware;

namespace Library.Services.Middleware
{
    /// <summary>
    /// AuthMiddleware
    /// </summary>
    /// <seealso cref="Library.System.Libs.Interfaces.IMiddleware" />
    public class AuthMiddleware : IMiddleware
    {
        public RequestDelegate _next { get; set; }
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="tokenValidationParameters">The token validation parameters.</param>
        public AuthMiddleware(
            RequestDelegate next,
            ILogger<AuthMiddleware> logger,
            TokenValidationParameters tokenValidationParameters)
        {
            _next = next;
            _logger = logger;
            _tokenValidationParameters = tokenValidationParameters;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {

            if (string.Compare(context.Request.GetUri().Segments[1], "swagger/", StringComparison.OrdinalIgnoreCase) == 0)
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                _logger.LogInformation($"UNAUTHORIZED | {context.Request.GetIPAddress()} | {context.Request.GetUri()}");
                context.Response.StatusCode = 401; //UnAuthorized
                await context.Response.WriteAsync("Missing authorization header");
                return;
            }
            try
            {
                var name = context.Request.GetClaim("name", _tokenValidationParameters);
                _logger.LogInformation($"PASSED | {context.Request.GetIPAddress()} | {name} | {context.Request.GetUri()}");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 401; //UnAuthorized
                _logger.LogInformation($"UNAUTHORIZED | {context.Request.GetIPAddress()} | {context.Request.GetUri()} | {ex.Message}");
                await context.Response.WriteAsync(ex.Message);
                return;
            }
            await _next(context);
        }
    }
}
