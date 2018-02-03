using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Library.System.Libs.Interfaces;

namespace Library.System.Libs
{
    /// <summary>
    /// WebApiHelper
    /// </summary>
    public class WebApiHelper : IWebApiHelper
    {
        private readonly HttpClient client;
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiHelper"/> class.
        /// </summary>
        public WebApiHelper()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddHeader(string key, string value)
        {
            RemoveHeader(key);
            client.DefaultRequestHeaders.Add(key, value);
        }

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        public void AddHeader(string key, IEnumerable<string> values)
        {
            RemoveHeader(key);
            client.DefaultRequestHeaders.Add(key, values);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get(string url)
        {
            var response = await client.GetAsync(url);
            await ValidateResponse(response);
            return response;
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post(string url, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response =  await client.PostAsync(url, content);
            await ValidateResponse(response);
            return response;
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Put(string url, string data)
        {
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            await ValidateResponse(response);
            return response;
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Delete(string url)
        {
            var response = await client.DeleteAsync(url);
            await ValidateResponse(response);
            return response;
        }

        /// <summary>
        /// Removes the header.
        /// </summary>
        /// <param name="key">The key.</param>
        private void RemoveHeader(string key)
        {
            if (client.DefaultRequestHeaders.Any(i => i.Key == key))
            {
                client.DefaultRequestHeaders.Remove(key);
            }
        }

        private static async Task ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                        throw new UnauthorizedAccessException(await response.Content.ReadAsStringAsync());
                    case HttpStatusCode.UnsupportedMediaType:
                        throw new ArgumentException(await response.Content.ReadAsStringAsync());
                    default:
                        throw new WebException(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
