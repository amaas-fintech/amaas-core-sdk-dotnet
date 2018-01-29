using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Extensions;
using AMaaS.Core.Sdk.Transactions.Enums;
using AMaaS.Core.Sdk.Transactions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AMaaS.Core.Sdk.Transactions
{
    public class TransactionsInterface : AMaaSInterfaceBase, ITransactionsInterface
    {
        #region Properties

        public override string EndpointType => EndpointTypes.Transactions;

        #endregion

        #region Constructor

        public TransactionsInterface(AMaaSSession session) : base(session) 
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Transaction>> SearchTransactions(
            int assetManagerId,
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
            List<string> childTypes = null,
            int? pageNo = null,
            int? pageSize = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (!transactionIds.IsNullOrEmpty())
                queryParams.Add("transaction_ids", transactionIds.StringJoin());
            if (!transactionStatuses.IsNullOrEmpty())
                queryParams.Add("transaction_statuses", transactionStatuses.StringJoin());
            if (!assetBookIds.IsNullOrEmpty())
                queryParams.Add("asset_book_ids", assetBookIds.StringJoin());
            if (!counterpartyBookIds.IsNullOrEmpty())
                queryParams.Add("counterparty_book_ids", counterpartyBookIds.StringJoin());
            if (!assetIds.IsNullOrEmpty())
                queryParams.Add("asset_ids", assetIds.StringJoin());
            if (transactionDateStart.HasValue)
                queryParams.Add("transaction_date_start", transactionDateStart.Value.ToISODateString());
            if (transactionDateEnd.HasValue)
                queryParams.Add("transaction_date_end", transactionDateEnd.Value.ToISODateString());
            if (!codeTypes.IsNullOrEmpty())
                queryParams.Add("code_types", codeTypes.StringJoin());
            if (!codeValues.IsNullOrEmpty())
                queryParams.Add("code_values", codeValues.StringJoin());
            if (!linkTypes.IsNullOrEmpty())
                queryParams.Add("link_types", linkTypes.StringJoin());
            if (!linkedTransactionIds.IsNullOrEmpty())
                queryParams.Add("linked_transaction_ids", linkedTransactionIds.StringJoin());
            if (!partyTypes.IsNullOrEmpty())
                queryParams.Add("party_types", partyTypes.StringJoin());
            if (!partyIds.IsNullOrEmpty())
                queryParams.Add("party_ids", partyIds.StringJoin());
            if (!referenceTypes.IsNullOrEmpty())
                queryParams.Add("reference_types", referenceTypes.StringJoin());
            if (!referenceValues.IsNullOrEmpty())
                queryParams.Add("reference_values", referenceValues.StringJoin());
            if (!clientIds.IsNullOrEmpty())
                queryParams.Add("client_ids", clientIds.StringJoin());
            if (!fields.IsNullOrEmpty())
                queryParams.Add("fields", fields.StringJoin());
            if (!childTypes.IsNullOrEmpty())
                queryParams.Add("childTypes", childTypes.StringJoin());
            if (pageNo.HasValue)
                queryParams.Add("page_no", pageNo.ToString());
            if (pageSize.HasValue)
                queryParams.Add("page_size", pageSize.ToString());
            
            return await Session.GetAsync<List<Transaction>>($"{EndpointType}/transactions/{assetManagerId}", queryParams);
        }

        public async Task<IEnumerable<Position>> SearchPositions(
            int assetManagerId,
            DateTime? positionDate = null, 
            List<string> bookIds = null, 
            List<string> accountIds = null, 
            List<string> accountingTypes = null, 
            List<string> assetIds = null,
            int? pageNo = null,
            int? pageSize = null)
        {
            var queryParams = new Dictionary<string, string>();

            if (positionDate.HasValue)
                queryParams.Add("position_date", positionDate.Value.ToISODateString());
            if (!bookIds.IsNullOrEmpty())
                queryParams.Add("book_ids", bookIds.StringJoin());
            if (!accountIds.IsNullOrEmpty())
                queryParams.Add("account_ids", accountIds.StringJoin());
            if (pageNo.HasValue)
                queryParams.Add("page_no", pageNo.ToString());
            if (pageSize.HasValue)
                queryParams.Add("page_size", pageSize.ToString());

            return await Session.GetAsync<List<Position>>($"{EndpointType}/positions/{assetManagerId}", queryParams);
        }

        #endregion
    }
}
