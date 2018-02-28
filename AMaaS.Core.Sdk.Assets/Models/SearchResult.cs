using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Assets.Models
{
    public class SearchResult
    {
        public IEnumerable<Asset> Hits { get; set; }
        public int Total { get; set; }
        public decimal MaxScore { get; set; }
    }
}
