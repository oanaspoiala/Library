using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Library.Presentation.Filters
{
    public class LibraryPresentationExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;

        public LibraryPresentationExceptionFilter(ILogger<LibraryPresentationExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status;
            string message;

            logger.LogError(context.Exception, context.Exception.ToString());

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
