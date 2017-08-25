using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaaS.Core.Sdk.Constants
{
    public static class ConfigurationKeys
    {
        public const string CognitoPoolId = "cognito_pool_id";
        public const string CognitoClientId = "cognito_client_id";
        public const string AwsRegion = "aws_region";
        public const string Username = "username";
        public const string Password = "password";
        public const string Environment = "environment";
        public const string SdkVersion = "sdk_version";
        public const string AuthSection = "auth";
        public const string AMaaSConfigFile = ".amaas.cfg";
    }
}
