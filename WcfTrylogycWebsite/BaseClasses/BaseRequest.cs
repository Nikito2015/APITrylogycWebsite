using System.Runtime.Serialization;
using WcfTrylogycWebsite.ServiceRequests.Interfaces;

namespace WcfTrylogycWebsite.ServiceRequests
{

    [DataContract]
    /// <summary>
    /// Base Request
    /// </summary>
    public abstract class BaseRequest : IBaseRequest
    {

        #region Public Properties
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        [DataMember]
        public string Token { get; set; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsValid();
        #endregion
    }
}