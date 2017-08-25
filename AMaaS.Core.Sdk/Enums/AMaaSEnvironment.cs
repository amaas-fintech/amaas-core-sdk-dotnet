using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AMaaS.Core.Sdk.Enums
{
    public enum AMaaSEnvironment
    {
        [EnumMember(Value = "local")]
        Local,
        [EnumMember(Value = "dev")]
        Dev,
        [EnumMember(Value = "staging")]
        Staging,
        [EnumMember(Value = "prod")]
        Prod
    }
}
