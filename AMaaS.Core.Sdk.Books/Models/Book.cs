using AMaaS.Core.Sdk.Books.Enums;
using AMaaS.Core.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Books.Models
{
    public class Book : AMaaSModel
    {
        #region Properties

        public int AssetManagerId { get; set; }
        public string BookId { get; set; } = Guid.NewGuid().ToString();
        public BookType BookType { get; set; }
        public BookStatus BookStatus { get; set; }
        public string OwnerId { get; set; }
        public string PartyId { get; set; }
        public DateTime CloseTime { get; set; }
        public string TimeZone { get; set; }
        public string BaseCurrency { get; set; }
        public string BusinessUnit { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        #endregion
    }
}
