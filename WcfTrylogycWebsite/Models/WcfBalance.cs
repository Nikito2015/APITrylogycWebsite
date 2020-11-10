using CommonTrylogycWebsite.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTrylogycWebsite.Models
{

    /// <summary>
    /// WcfBalance class
    /// </summary>
    public class WcfBalance
    {

        #region Properties
        [DataMember]
        public int AssociateId { get; set; }

        [DataMember]
        public int ConnectionId { get; set; }

        [DataMember]
        public string Period { get; set; }

        [DataMember]
        public string InvoiceGroup { get; set; }

        [DataMember]
        public string InvoiceLetter { get; set; }

        [DataMember]
        public string InvoicePoint { get; set; }

        [DataMember]
        public string InvoiceNumber { get; set; }

        [DataMember]
        public string InvoiceDate { get; set; }

        [DataMember]
        public string InvoiceExpirationDate { get; set; }

        [DataMember]
        public string InvoiceAmmount { get; set; }

        [DataMember]
        public string InvoiceTrackingNumber { get; set; }

        [DataMember]
        public bool Paid { get; set; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the balances collection from dto.
        /// </summary>
        /// <param name="balances">The balances.</param>
        /// <returns></returns>
        public static List<WcfBalance> CreateBalancesCollectionFromDTO(IEnumerable<IDTOBalance> balances)
        {
            return balances?
                           .Select(a => new WcfBalance()
                           {
                               AssociateId = a.AssociateId,
                               ConnectionId = a.ConnectionId,
                               InvoiceAmmount = a.InvoiceAmmount,
                               InvoiceDate = a.InvoiceDate,
                               InvoiceExpirationDate = a.InvoiceExpirationDate,
                               InvoiceGroup = a.InvoiceGroup,
                               InvoiceLetter = a.InvoiceLetter,
                               InvoiceNumber = a.InvoiceNumber,
                               InvoicePoint = a.InvoicePoint,
                               InvoiceTrackingNumber = a.InvoiceTrackingNumber,
                               Paid = a.Paid,
                               Period = a.Period
                           })?.ToList();
        }
        #endregion
    }
}