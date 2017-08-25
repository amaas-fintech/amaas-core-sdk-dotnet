using AMaaS.Core.Sdk.Assets.Enums;
using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Assets.Models
{
    public class Asset : AMaaSModel
    {
        #region Properties

        public int AssetManagerId { get; set; }
        public string AssetId { get; set; }
        public AssetStatus AssetStatus { get; set; }
        public AssetClass AssetClass { get; set; }
        public string AssetType { get; set; }
        public bool Fungible { get; set; }
        public string AssetIssuerId { get; set; }
        public string CountryId { get; set; }
        public string VenueId { get; set; }
        public string Currency { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public bool RollPrice { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Additional { get; set; }
        public string ClientAdditional { get; set; }

        public Dictionary<string, Comment> Comments { get; set; } = new Dictionary<string, Comment>();
        public Dictionary<string, Link> Links { get; set; } = new Dictionary<string, Link>();
        public Dictionary<string, Reference> References { get; set; } = new Dictionary<string, Reference>();

        #endregion

        #region Constructor
        public Asset() : base()
        {
            if (!References.ContainsKey(AMaaSConstants.DefaultReference))
                References.Add(AMaaSConstants.DefaultReference, new Reference { ReferenceValue = AssetId });
        }
        #endregion
    }
}
