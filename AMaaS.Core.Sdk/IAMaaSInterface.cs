using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Contracts
{
    public interface IAMaaSInterface
    {
        string EndpointType { get; }
        string AuthorizationToken { get; }
    }
}
