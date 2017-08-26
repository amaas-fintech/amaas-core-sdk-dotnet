using AMaaS.Core.Sdk.AssetManagers.Enums;
using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.AssetManagers.Models
{
    public class Relationship : AMaaSModel
    {
        #region Properties

        public int AssetManagerId { get; set; }
        public int RelatedId { get; set; }
        public string RelationshipId { get; set; }
        public RelationshipStatus RelationshipStatus { get; set; }
        public RelationshipType RelationshipType { get; set; }

        #endregion
    }
}
