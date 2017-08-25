using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Enums
{
    public enum AccountingType
    {
        [EnumMember(Value = "Transaction Date")]
        TransactionDate,
        [EnumMember(Value = "Settlement Date")]
        SettlementDate
    }
}
