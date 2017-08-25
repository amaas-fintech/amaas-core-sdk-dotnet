using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type        = enumVal.GetType();
            var memInfo     = type.GetMember(enumVal.ToString());
            var attributes  = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetEnumDisplay(this Enum enumVal)
        {
            return enumVal.GetAttributeOfType<EnumMemberAttribute>().Value;
        }
    }
}
