using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMaaS.Core.Sdk.Enums;
using AMaaS.Core.Sdk.Constants;

namespace AMaaS.Core.Sdk.Configuration
{
    public class AMaaSConfigDev : AMaaSConfigBase
    {
        public override string CognitoPoolId => "us-west-2_wKa82vECF";
        public override string CognitoClientId => "5mrqm1sjmfp80k8foasq83rb9k";
        public override string AwsRegion => "us-west-2";
        public override AMaaSEnvironment Environment => AMaaSEnvironment.Dev;

        public AMaaSConfigDev(string apiVersion) : base(apiVersion)
        {

        }

        public AMaaSConfigDev(string username, string password, string apiVersion) : base(username, password, apiVersion)
        {

        }
    }
}
