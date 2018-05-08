namespace Library.System.Security.Interfaces
{
    public interface ITokenStorage
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        string Token { get; set; }
    }
}