using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Extensions;
using AMaaS.Core.Sdk.Parties.Models;

namespace AMaaS.Core.Sdk.Parties
{
    public class PartiesInterface : AMaaSInterfaceBase, IPartiesInterface
    {
        #region Properties

        public override string EndpointType => EndpointTypes.Parties;
        
        #endregion

        #region Constructor

        public PartiesInterface(AMaaSSession session) : base(session)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Party>> SearchParties(
            int assetManagerId, 
            List<string> partyIds = null, 
            List<string> partyClasses = null, 
            List<string> partyTypes = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (!partyIds.IsNullOrEmpty())
                queryParams.Add("party_ids", partyIds.StringJoin());
            if (!partyClasses.IsNullOrEmpty())
                queryParams.Add("party_classes", partyClasses.StringJoin());
            if (!partyTypes.IsNullOrEmpty())
                queryParams.Add("party_types", partyTypes.StringJoin());
            return await Session.GetAsync<List<Party>>($"{EndpointType}/parties/{assetManagerId}", queryParams);
        }

        #endregion
    }
}
