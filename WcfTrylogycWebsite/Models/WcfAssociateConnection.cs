using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTrylogycWebsite.Models
{

    /// <summary>
    /// WcfAssociateConnection class
    /// </summary>
    public class WcfAssociateConnection
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the associate identifier.
        /// </summary>
        /// <value>
        /// The associate identifier.
        /// </value>
        [DataMember]
        public int AssociateId { get; set; }

        /// <summary>
        /// Gets or sets the connection identifier.
        /// </summary>
        /// <value>
        /// The connection identifier.
        /// </value>
        [DataMember]
        public int ConnectionId { get; set; }

        #endregion
    }
}