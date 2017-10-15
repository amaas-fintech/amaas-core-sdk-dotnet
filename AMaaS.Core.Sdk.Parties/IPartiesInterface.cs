using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Contracts;
using AMaaS.Core.Sdk.Parties.Models;

namespace AMaaS.Core.Sdk.Parties
{
    public interface IPartiesInterface : IAMaaSInterface
    {
        Task<IEnumerable<Party>> SearchParties(int assetManagerId,
            List<string> partyIds = null,
            List<string> partyClasses = null,
            List<string> partyTypes = null);
    }
}
