using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Assets.Models;
using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Extensions;

namespace AMaaS.Core.Sdk.Assets
{
    public class AssetsInterface : AMaaSInterfaceBase, IAssetsInterface
    {
        #region Properties

        public override string EndpointType => EndpointTypes.Assets;

        #endregion

        #region Constructor

        public AssetsInterface(AMaaSSession session) : base(session)
        {

        }

        #endregion

        #region Methods
        
        public async Task<IEnumerable<Asset>> SearchAssets(
            int assetManagerId,
            List<string> assetIds = null,
            List<string> assetClasses = null,
            List<string> assetTypes = null,
            int? pageNo = null,
            int? pageSize = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (!assetIds.IsNullOrEmpty())
                queryParams.Add("asset_ids", assetIds.StringJoin());
            if (!assetClasses.IsNullOrEmpty())
                queryParams.Add("assetClasses", assetClasses.StringJoin());
            if (!assetTypes.IsNullOrEmpty())
                queryParams.Add("assetTypes", assetTypes.StringJoin());
            if (pageNo.HasValue)
                queryParams.Add("page_no", pageNo.ToString());
            if (pageSize.HasValue)
                queryParams.Add("page_size", pageSize.ToString());
            return await Session.GetAsync<List<Asset>>($"{EndpointType}/assets/{assetManagerId}", queryParams);
        }
        #endregion
    }
}
