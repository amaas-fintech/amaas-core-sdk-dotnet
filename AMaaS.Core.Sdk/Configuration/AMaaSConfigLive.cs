using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigLive : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_XlXESdzaC";
        public override string CognitoClientId => "2nl3v2vgivcrooiah804kjqrbm";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Live; }
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
