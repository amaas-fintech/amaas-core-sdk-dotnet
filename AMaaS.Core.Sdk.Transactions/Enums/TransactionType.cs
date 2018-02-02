using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Enums
{
    public enum TransactionType
    {
        Allocation,
        Block,
        Exercise,
        Expiry,
        Journal,
        Maturity,
        Net,
        Novation,
        Split,
        Trade,
        Transfer,
        Cashflow,
        Coupon,
        Dividend,
        Payment,
        Settlement
    }

    public enum CashTransactionType
    {
        Cashflow = TransactionType.Cashflow,
        Coupon   = TransactionType.Coupon,
        Dividend = TransactionType.Dividend,
        Payment  = TransactionType.Payment
    }
}
