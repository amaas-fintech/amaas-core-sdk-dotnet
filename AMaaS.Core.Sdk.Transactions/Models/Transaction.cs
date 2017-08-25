using System;
using System.Linq;
using AMaaS.Core.Sdk.Models;
using System.Collections.Generic;
using AMaaS.Core.Sdk.Transactions.Enums;
using AMaaS.Core.Sdk.Constants;

namespace AMaaS.Core.Sdk.Transactions.Models
{
    public class Transaction : AMaaSModel
    {
        #region Backing Fields

        private string _transactionCurrency;
        private string _settlementCurrency;

        #endregion

        #region Persisted Properties

        public int AssetManagerId { get; set; }
        public string AssetBookId { get; set; }
        public string CounterPartyBookId { get; set; }
        public TransactionAction TransactionAction { get; set; } = TransactionAction.Buy;
        public string AssetId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime SettlementDate { get; set; }
        public decimal Price { get; set; }
        public string TransactionCurrency
        {
            get { return _transactionCurrency; }
            set
            {
                if (value == null || value.Length != 3)
                    throw new ArgumentException(string.Format(ErrorMessages.CurrencyInvalid, value, TransactionId, AssetManagerId));
                _transactionCurrency = value;
            }
        }
        public string SettlementCurrency
        {
            get { return _settlementCurrency; }
            set
            {
                if (value == null || value.Length != 3)
                    throw new ArgumentException(string.Format(ErrorMessages.CurrencyInvalid, value, TransactionId, AssetManagerId));
                _settlementCurrency = value;
            }
        }
        public DateTime ExecutionTime { get; set; }
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public TransactionType? TransactionType { get; set; } = Enums.TransactionType.Trade;
        public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.New;

        public Dictionary<string, Charge> Charges { get; set; } = new Dictionary<string, Charge>();
        public Dictionary<string, Code> Codes { get; set; } = new Dictionary<string, Code>();
        public Dictionary<string, Comment> Comments { get; set; } = new Dictionary<string, Comment>();
        public Dictionary<string, List<Link>> Links { get; set; } = new Dictionary<string, List<Link>>();
        public Dictionary<string, Party> Parties { get; set; } = new Dictionary<string, Party>();
        public Dictionary<string, Rate> Rates { get; set; } = new Dictionary<string, Rate>();
        public Dictionary<string, Reference> References { get; set; } = new Dictionary<string, Reference>();

        #endregion

        #region Calculated Properties
        public decimal ChargesNetEffect => Charges.Values.Where(x => x.NetAffecting)
                                                         .Select(x => x.ChargeValue)
                                                         .Sum();
        public decimal GrossSettlement => Quantity * Price;
        public decimal NetSettlement => GrossSettlement - ChargesNetEffect;

        #endregion

        #region Constructor

        public Transaction() : base()
        {
            if (!References.ContainsKey(AMaaSConstants.DefaultReference))
                References.Add(AMaaSConstants.DefaultReference, new Reference { ReferenceValue = TransactionId });
        }
        #endregion
    }
}
