using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.System.Libs.Interfaces
{
    public interface IWebApiHelper
    {
        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void AddHeader(string key, string value);

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        void AddHeader(string key, IEnumerable<string> values);

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> Get(string url);

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> Post(string url, string data);

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> Put(string url, string data);

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> Delete(string url);
    }
}