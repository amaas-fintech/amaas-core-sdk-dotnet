using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMaaS.Core.Sdk.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string StringJoin<T>(this IEnumerable<T> collection, string separator = ",") => string.Join(separator, collection);
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || collection.Count() == 0;
    }
}
