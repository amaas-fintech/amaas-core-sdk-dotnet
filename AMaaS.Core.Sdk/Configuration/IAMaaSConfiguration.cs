using AMaaS.Core.Sdk.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Configuration
{
    public interface IAMaaSConfiguration
    {
        string CognitoPoolId { get; }
        string CognitoClientId { get; }
        string AwsRegion { get; }
        string Username { get; }
        string Password { get; }
        AMaaSEnvironment Environment { get; }
        Uri Endpoint { get; }
        string ApiVersion { get; }
        bool IsInitialized { get; }
    }
}
