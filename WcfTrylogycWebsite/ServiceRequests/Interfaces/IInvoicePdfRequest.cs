using System.Runtime.Serialization;

namespace WcfTrylogycWebsite.ServiceRequests.Interfaces
{

    /// <summary>
    /// Interface for an invoice pdf request
    /// </summary>
    /// <seealso cref="WcfTrylogycWebsite.ServiceRequests.Interfaces.IBaseRequest" />
    public interface IInvoicePdfRequest : IBaseRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [request from FTP].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [request from FTP]; otherwise, <c>false</c>.
        /// </value>
        bool RetrieveFromFTP { get; set; }

        #endregion
    }


}