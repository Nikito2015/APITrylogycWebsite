using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTrylogycWebsite.ServiceResponses
{

    /// <summary>
    /// Class that represents an invoice pdf response
    /// </summary>
    /// <seealso cref="WcfTrylogycWebsite.ServiceResponses.BaseResponse" />
    [DataContract]
    public class InvoicePdfResponse : BaseResponse
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the invoice PDF.
        /// </summary>
        /// <value>
        /// The invoice PDF.
        /// </value>
        [DataMember]
        public string InvoicePdf { get; set; }

        #endregion
    }
}