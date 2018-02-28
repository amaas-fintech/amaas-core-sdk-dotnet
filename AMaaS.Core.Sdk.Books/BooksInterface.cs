using AMaaS.Core.Sdk.Books.Enums;
using AMaaS.Core.Sdk.Books.Models;
using AMaaS.Core.Sdk.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Extensions;

namespace AMaaS.Core.Sdk.Books
{
    public class BooksInterface : AMaaSInterfaceBase, IBooksInterface
    {
        #region Properties

        public override string EndpointType => EndpointTypes.Books;

        #endregion

        #region Constructor

        public BooksInterface(AMaaSSession session) : base(session)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Book>> SearchBooks(
            int assetManagerId, 
            List<string> bookIds = null, 
            List<string> partyIds = null, 
            List<BookStatus> bookStatuses = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (!bookIds.IsNullOrEmpty())
                queryParams.Add("book_ids", bookIds.StringJoin());
            if (!partyIds.IsNullOrEmpty())
                queryParams.Add("party_ids", partyIds.StringJoin());
            if (!bookStatuses.IsNullOrEmpty())
                queryParams.Add("book_statuses", bookStatuses.StringJoin());
            
            return await Session.GetAsync<List<Book>>($"{EndpointType}/books/{assetManagerId}", queryParams);
        }

        #endregion
    }
}
