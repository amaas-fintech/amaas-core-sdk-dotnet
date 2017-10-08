using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigDev : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_De6j7TWIB";
        public override string CognitoClientId => "2qk35mhjjpk165vssuqhqoi1lk";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Dev; }
            set { }
        }

        public AMaaSConfigDev(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigDev(string username, string password, string apiVersion) : 
            base(username, password, apiVersion)
        {

        }
    }
}
