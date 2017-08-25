using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Enums
{
    public enum TransactionAction
    {
        Buy,
        Sell,
        [EnumMember(Value = "Short Sell")]
        ShortSell,
        Deliver,
        Receive,
        Acquire,
        Remove,
        Redemption,
        Subscription
    }
}
