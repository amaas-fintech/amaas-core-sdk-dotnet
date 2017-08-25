using AMaaS.Core.Sdk.Models;
using AMaaS.Core.Sdk.Transactions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Transactions.Models
{
    public class Position : AMaaSModel
    {
        #region Backing Fields

        #endregion

        #region Properties

        public int AssetManagerId { get; set; }
        public string BookId { get; set; }
        public string AssetId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string AccountId { get; set; }
        public AccountingType AccountingType { get; set; }

        #endregion
    }
}
