using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigLive : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_yoy5sStQz";
        public override string CognitoClientId => "5l4953h3l5klj0ir9klqhod0rn";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Default; }
            set { }
        }

        public AMaaSConfigLive(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigLive(string username, string password, string apiVersion) :
            base(username, password, apiVersion)
        {

        }
    }
}
