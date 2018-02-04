using System;
using System.Collections.Generic;
using System.Text;
using Library.System.Security.Interfaces;

namespace Library.System.Security
{
    /// <summary>
    /// TokenStorage
    /// </summary>
    public class TokenStorage : ITokenStorage
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
