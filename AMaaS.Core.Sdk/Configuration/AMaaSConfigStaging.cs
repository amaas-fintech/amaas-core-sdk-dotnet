using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Enums;
using AMaaS.Core.Sdk.Constants;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigStaging : AMaaSConfigBase
    {
        public override string CognitoPoolId => "ap-southeast-1_De6j7TWIB";
        public override string CognitoClientId => "2qk35mhjjpk165vssuqhqoi1lk";
        public override string AwsRegion => "ap-southeast-1";
        public override AMaaSEnvironment Environment
        {
            get { return AMaaSEnvironment.Staging; }
            set { }
        }

        public AMaaSConfigStaging(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigStaging(string username, string password, string apiVersion) : base(username, password, apiVersion)
        {

        }
    }
}
