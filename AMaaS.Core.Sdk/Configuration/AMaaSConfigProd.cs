using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigProd : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_0LilJdUR3";
        public override string CognitoClientId => "7b7kt883veb7rr2toolj1ukp6j";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Prod; }
            set { }
        }

        public AMaaSConfigProd(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigProd(string username, string password, string apiVersion) : 
            base(username, password, apiVersion)
        {

        }
    }
}
