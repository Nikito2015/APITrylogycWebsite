using CommonTrylogycWebsite.DTO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WcfTrylogycWebsite.Models
{

    /// <summary>
    /// Class that represents a wcf Associate
    /// </summary>
    public class WcfAssociate
    {
        #region Public Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ConnectionId { get; set; }

        [DataMember]
        public string CGP { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Document { get; set; }

        #endregion

        /// <summary>
        /// Creates the associates collection from dto.
        /// </summary>
        /// <param name="associates">The associates.</param>
        /// <returns></returns>
        public static List<WcfAssociate> CreateAssociatesCollectionFromDTO(IEnumerable<IDTOAssociate> associates)
        {
            return associates?
                             .Select(a => new WcfAssociate()
                             {
                                 Id = a.Id,
                                 Address = a.Address,
                                 CGP = a.CGP,
                                 City = a.City,
                                 ConnectionId = a.ConnectionId,
                                 Document = a.Document,
                                 Name = a.Name
                             })?.ToList();
        }
    }
}