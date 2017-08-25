using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToISODateString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");
        public static string ToISODateTimeString(this DateTime dateTime) => dateTime.ToString("O");
    }
}
