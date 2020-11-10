using System.Runtime.Serialization;
using WcfTrylogycWebsite.ServiceRequests.Interfaces;

namespace WcfTrylogycWebsite.ServiceRequests
{

    /// <summary>
    /// Class for an invoicePdfRequest
    /// </summary>
    /// <seealso cref="WcfTrylogycWebsite.ServiceRequests.BaseRequest" />
    /// <seealso cref="WcfTrylogycWebsite.ServiceRequests.Interfaces.IInvoicePdfRequest" />
    public class InvoicePdfRequest : BaseRequest, IInvoicePdfRequest
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

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        /// <value>
        /// The invoice number.
        /// </value>
        [DataMember]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [request from FTP].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [request from FTP]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool RetrieveFromFTP { get; set; }

        #endregion

        #region Public Methdos

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid()
        {
            return (!string.IsNullOrEmpty(InvoiceNumber));
        }
        #endregion
    }
}