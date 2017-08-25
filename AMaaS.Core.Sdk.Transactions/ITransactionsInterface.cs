using AMaaS.Core.Sdk.Contracts;
using AMaaS.Core.Sdk.Transactions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Transactions
{
    public interface ITransactionsInterface : IAMaaSInterface
    {
        Task<IEnumerable<Transaction>> SearchTransactions(
            List<int> assetManagerIds = null,
            List<string> transactionIds = null,
            List<string> transactionStatuses = null,
            List<string> assetBookIds = null,
            List<string> counterpartyBookIds = null,
            List<string> assetIds = null,
            DateTime? transactionDateStart = null,
            DateTime? transactionDateEnd = null,
            List<string> codeTypes = null,
            List<string> codeValues = null,
            List<string> linkTypes = null,
            List<string> linkedTransactionIds = null,
            List<string> partyTypes = null,
            List<string> partyIds = null,
            List<string> referenceTypes = null,
            List<string> referenceValues = null,
            List<string> clientIds = null,
            List<string> fields = null,
            int? pageNo = null,
            int? pageSize = null);

        Task<IEnumerable<Position>> SearchPositions(
            DateTime? positionDate = null,
            List<int> assetManagerIds = null,
            List<string> bookIds = null,
            List<string> accountIds = null,
            List<string> accountingTypes = null,
            List<string> assetIds = null);
    }
}
