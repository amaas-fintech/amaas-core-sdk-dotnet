using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Enums
{
    public enum TransactionStatus
    {
        New,
        Amended,
        Cancelled,
        Superseded,
        Netted,
        Novated
    }
}
