﻿using System.Runtime.Serialization;
using WcfTrylogycWebsite.ServiceRequests.Interfaces;

namespace WcfTrylogycWebsite.ServiceRequests
{
    /// <summary>
    /// Class that contains properties for registering a user
    /// </summary>
    [DataContract]
    public class RegisterRequest : BaseRequest, IRegisterRequest
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the email confirm.
        /// </summary>
        /// <value>
        /// The email confirm.
        /// </value>
        [DataMember]
        public string EmailConfirm { get; set; }

        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        /// <value>
        /// The codigo.
        /// </value>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the CGP.
        /// </summary>
        /// <value>
        /// The CGP.
        /// </value>
        [DataMember]
        public string CGP { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [email invoices].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [email invoices]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool EmailInvoices { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid()
        {
            return (!string.IsNullOrEmpty(Email) ||
                        !string.IsNullOrEmpty(EmailConfirm) ||
                            !string.IsNullOrEmpty(Code) ||
                                !string.IsNullOrEmpty(CGP));
        }

        #endregion
    }
}