using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using AMaaS.Core.Sdk.Contracts;
using System.Runtime.Serialization;

namespace AMaaS.Core.Sdk.Models
{
    public abstract class AMaaSModel
    {
        #region Properties

        public int Version { get; set; } = 1;
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; } = DateTime.UtcNow;

        #endregion

    }
}
