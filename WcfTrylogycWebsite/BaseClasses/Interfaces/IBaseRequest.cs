namespace WcfTrylogycWebsite.ServiceRequests.Interfaces
{

    /// <summary>
    /// Interface for a base request
    /// </summary>
    public interface IBaseRequest
    {

        #region Properties
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        string Token { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid();
        #endregion
    }
}