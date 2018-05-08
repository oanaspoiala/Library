using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Library.System.Libs.Interfaces;
using Library.System.Security.Interfaces;

namespace Library.System.Libs
{
    /// <summary>
    /// WebApiHelper
    /// </summary>
    public class WebApiHelper : IWebApiHelper
    {
        private readonly HttpClient _client;
        private readonly ITokenStorage _tokenStorage;
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiHelper" /> class.
        /// </summary>
        /// <param name="tokenStorage">The token storage.</param>
        public WebApiHelper(ITokenStorage tokenStorage)
        {
            // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Ik9hbmEgU3BvaWFsYSIsImFkbWluIjp0cnVlfQ.yX9R-Q-GPQ0yAn1JadUiqnoLPmtAXY-KZB7fKdxChiA"
            _tokenStorage = tokenStorage;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Adds the authorization header.
        /// </summary>
        /// <param name="jwt">The JWT.</param>
        public void AddAuthorizationHeader(string jwt)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddHeader(string key, string value)
        {
            RemoveHeader(key);
            _client.DefaultRequestHeaders.Add(key, value);
        }

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        public void AddHeader(string key, IEnumerable<string> values)
        {
            RemoveHeader(key);
            _client.DefaultRequestHeaders.Add(key, values);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                GetAuthenticationToken();
                response = await _client.GetAsync(url);
            }

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
            var response =  await _client.PostAsync(url, content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                GetAuthenticationToken();
                response = await _client.PostAsync(url, content);
            }

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
            var response = await _client.PutAsync(url, content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                GetAuthenticationToken();
                response = await _client.PutAsync(url, content);
            }

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
            var response = await _client.DeleteAsync(url);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                GetAuthenticationToken();
                response = await _client.DeleteAsync(url);
            }

            await ValidateResponse(response);
            return response;
        }

        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="WebException"></exception>
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

        /// <summary>
        /// Removes the header.
        /// </summary>
        /// <param name="key">The key.</param>
        private void RemoveHeader(string key)
        {
            if (_client.DefaultRequestHeaders.Any(i => i.Key == key))
            {
                _client.DefaultRequestHeaders.Remove(key);
            }
        }

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        private void GetAuthenticationToken()
        {
            _tokenStorage.Token =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Ik9hbmEgU3BvaWFsYSIsImFkbWluIjp0cnVlfQ.yX9R-Q-GPQ0yAn1JadUiqnoLPmtAXY-KZB7fKdxChiA";
            AddAuthorizationHeader(_tokenStorage.Token);
        }
    }
}
