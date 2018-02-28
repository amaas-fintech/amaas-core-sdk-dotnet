using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigDefault : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_GgjAUqD4G";
        public override string CognitoClientId => "3vh2298dbltafvbmu8me6536rq";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Default; }
            set { }
        }

        public AMaaSConfigDefault(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigDefault(string username, string password, string apiVersion) :
            base(username, password, apiVersion)
        {

        }
    }
}
