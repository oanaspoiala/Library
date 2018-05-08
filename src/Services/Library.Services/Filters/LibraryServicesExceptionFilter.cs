using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Library.Services.Filters
{
    public class LibraryServicesExceptionFilter  : IExceptionFilter
    {

        private readonly ILogger _logger;

        public LibraryServicesExceptionFilter(ILogger<LibraryServicesExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;

            _logger.LogError(context.Exception, context.Exception.ToString());

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                //TODO: use authentication
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = $"{message} {context.Exception.StackTrace}";
            response.WriteAsync(err);
        }
    }
}
