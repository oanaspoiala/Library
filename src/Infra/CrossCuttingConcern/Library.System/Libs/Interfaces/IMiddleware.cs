using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Library.System.Libs.Interfaces
{
    /// <summary>
    /// IMiddleware
    /// </summary>
    public interface IMiddleware
    {
        /// <summary>
        /// Sets the next.
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        RequestDelegate _next { set; }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        Task Invoke(HttpContext context);
    }
}
