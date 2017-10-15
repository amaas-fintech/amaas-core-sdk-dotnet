using AMaaS.Core.Sdk.Assets.Models;
using AMaaS.Core.Sdk.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Assets
{
    public interface IAssetsInterface : IAMaaSInterface
    {
        Task<IEnumerable<Asset>> SearchAssets(
            int assetManagerId,
            List<string> assetIds = null,
            List<string> assetClasses = null,
            List<string> assetTypes = null,
            int? pageNo = null,
            int? pageSize = null);
    }
}
