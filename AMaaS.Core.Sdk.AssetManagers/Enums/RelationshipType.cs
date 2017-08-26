using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.AssetManagers.Enums
{
    public enum RelationshipType
    {
        Administrator,
        External,
        [EnumMember(Value = "Front Office")]
        FrontOffice,
        Employee
    }
}
