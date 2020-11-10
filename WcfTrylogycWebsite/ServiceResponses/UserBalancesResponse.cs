using System.Collections.Generic;
using System.Runtime.Serialization;
using WcfTrylogycWebsite.Models;

namespace WcfTrylogycWebsite.ServiceResponses
{
    [DataContract]
    public class UserBalancesResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the balances.
        /// </summary>
        /// <value>
        /// The balances.
        /// </value>
        [DataMember]
        public List<WcfBalance> Balances { get; set; }

        #endregion
    }
}