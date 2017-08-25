using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Models
{
    public class Posting : AMaaSModel
    {
        #region Properties

        public string AssetId { get; set; }
        public string BookId { get; set; }
        public string AccountId { get; set; }
        public string AccountingType { get; set; }
        public DateTime PostingDate { get; set; }
        public decimal Quantity { get; set; }
        public string Reason { get; set; }
        public bool Lifecycle { get; set; }

        #endregion
    }
}
