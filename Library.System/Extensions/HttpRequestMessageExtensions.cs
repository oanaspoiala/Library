using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Library.System.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static string GetIPAddress(this HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GetHeaderValue(this HttpRequest request, string key)
        {
            return request.Headers.Any(x => string.Compare(x.Key, key, StringComparison.OrdinalIgnoreCase) == 0)
                ? request.Headers.FirstOrDefault(x =>
                    string.Compare(x.Key, key, StringComparison.OrdinalIgnoreCase) == 0).Value.First()
                : string.Empty;
        }

        public static string GetClaim(this HttpRequest request, string claim, TokenValidationParameters tokenValidationParameters)
        {
            var authorization = request.GetHeaderValue("Authorization");
            if (string.IsNullOrEmpty(authorization))
            {
                throw new SecurityException("Not authenticated.");
            }

            var token = authorization.Replace("Bearer", string.Empty).Trim();

            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out var _);

            var result = claimsPrincipal.Claims.First(x => x.Type == claim)?.Value;

            return result;
        }
    }
}
