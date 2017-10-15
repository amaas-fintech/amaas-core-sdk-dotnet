using System;
using System.Collections.Generic;
using System.Text;
using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Models;

namespace AMaaS.Core.Sdk.Parties.Models
{
    public class Party : AMaaSModel
    {
        #region Persisted Properties

        public int ClientId { get; set; }
        public int AssetManagerId { get; set; }
        public string PartyId { get; set; }
        public string PartyClass { get; set; }
        public string PartyType { get; set; }
        public string PartyStatus { get; set; }
        public string BaseCurrency { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string LegalName { get; set; }
        public string Url { get; set; }
        public string Additional { get; set; }
        public Dictionary<string, Reference> References { get; set; } = new Dictionary<string, Reference>();
        public Dictionary<string, Comment> Comments { get; set; } = new Dictionary<string, Comment>();
        //Links
        //Addresses
        //Emails
        //Phone Numbers

        #endregion

        #region Constructor

        public Party()
        {
            if (!References.ContainsKey(AMaaSConstants.DefaultReference))
                References.Add(AMaaSConstants.DefaultReference, new Reference { ReferenceValue = PartyId, ReferencePrimary = true});
        }

        #endregion
    }
}
