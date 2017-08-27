using AMaaS.Core.Sdk.AssetManagers.Enums;
using AMaaS.Core.Sdk.AssetManagers.Models;
using AMaaS.Core.Sdk.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.AssetManagers
{
    public interface IAssetManagersInterface : IAMaaSInterface
    {
        Task<IEnumerable<Relationship>> GetUserRelationships(
            int userAssetManagerId, 
            IEnumerable<RelationshipType> relationshipTypes = null);
    }
}
