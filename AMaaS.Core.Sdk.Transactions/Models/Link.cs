using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Models
{
    public class Link : AMaaSModel
    {
        #region Properties

        public string LinkedTransactionId { get; set; }

        #endregion
    }
}
