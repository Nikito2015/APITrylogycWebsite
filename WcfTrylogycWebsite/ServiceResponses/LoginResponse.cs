using System.Runtime.Serialization;
using WcfTrylogycWebsite.Models;

namespace WcfTrylogycWebsite.ServiceResponses
{

    /// <summary>
    /// Login Response class.
    /// </summary>
    [DataContract]
    public class LoginResponse : BaseResponse
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

        /// <summary>
        /// Gets or sets the dto user.
        /// </summary>
        /// <value>
        /// The dto user.
        /// </value>
        [DataMember]
        public WcfUser User { get; set; }

        #endregion
    }
}