using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Transactions.Models
{
    public class Charge : AMaaSModel
    {
        #region Properties

        public decimal ChargeValue { get; set; }
        public bool NetAffecting { get; set; }

        #endregion
    }
}
