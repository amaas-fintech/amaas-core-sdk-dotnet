using AMaaS.Core.Sdk.Books.Enums;
using AMaaS.Core.Sdk.Books.Models;
using AMaaS.Core.Sdk.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Books
{
    public interface IBooksInterface : IAMaaSInterface
    {
        Task<IEnumerable<Book>> SearchBooks(
            int assetManagerId,
            List<string> bookIds = null,
            List<string> partyIds = null,
            List<BookStatus> bookStatuses = null);
    }
}
