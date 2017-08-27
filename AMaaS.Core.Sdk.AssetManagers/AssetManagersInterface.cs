using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.AssetManagers.Enums;
using AMaaS.Core.Sdk.AssetManagers.Models;
using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Extensions;

namespace AMaaS.Core.Sdk.AssetManagers
{
    public class AssetManagersInterface : AMaaSInterfaceBase, IAssetManagersInterface
    {
        #region Properties

        public override string EndpointType => EndpointTypes.AssetManagers;

        #endregion

        #region Constructor

        public AssetManagersInterface(AMaaSSession session) : base(session)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Relationship>> GetUserRelationships(
            int userAssetManagerId, 
            IEnumerable<RelationshipType> relationshipTypes = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (!relationshipTypes.IsNullOrEmpty())
                queryParams.Add("relationship_types", relationshipTypes.StringJoin());
            return await Session.GetAsync<List<Relationship>>($"{EndpointType}/asset-manager-related-amid/{userAssetManagerId}", queryParams);
        }

        #endregion
    }
}
