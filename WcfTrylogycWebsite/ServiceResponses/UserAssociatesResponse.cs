using System.Collections.Generic;
using System.Runtime.Serialization;
using WcfTrylogycWebsite.Models;

namespace WcfTrylogycWebsite.ServiceResponses
{
    [DataContract]
    public class UserAssociatesResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the associates.
        /// </summary>
        /// <value>
        /// The associates.
        /// </value>
        [DataMember]
        public List<WcfAssociate> Associates { get; set; }

        #endregion
    }
}