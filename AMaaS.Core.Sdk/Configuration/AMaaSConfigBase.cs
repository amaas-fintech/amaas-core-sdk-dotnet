using System;
using AMaaS.Core.Sdk.Enums;
using System.IO;
using AMaaS.Core.Sdk.Constants;
using IniParser;

namespace AMaaS.Core.Sdk.Configuration
{
    public abstract class AMaaSConfigBase : IAMaaSConfiguration
    {
        public abstract string CognitoPoolId { get; }
        public abstract string CognitoClientId { get; }
        public abstract string AwsRegion { get; }
        public abstract AMaaSEnvironment Environment { get; set; }
        public virtual string ApiVersion { get; }
        public virtual Uri Endpoint => Endpoints.Uris[Environment];
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public bool IsInitialized { get; }

        public AMaaSConfigBase(string username, string password, string apiVersion)
        {
            Username   = username;
            Password   = password;
            ApiVersion = apiVersion;
        }

        public AMaaSConfigBase(string apiVersion)
        {
            if(!IsInitialized)
            {
                var userHome    = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
                var amaasConfig = Path.Combine(userHome, ConfigurationKeys.AMaaSConfigFile);

                if (!File.Exists(amaasConfig))
                    throw new ApplicationException($"Missing configuration file: {amaasConfig}");

                var parser = new FileIniDataParser();
                var data = parser.ReadFile(amaasConfig);

                if (!data.Sections.ContainsSection(ConfigurationKeys.AuthSection))
                    throw new ApplicationException($"Missing section [{ConfigurationKeys.AuthSection}] in {amaasConfig}");

                if (!data[ConfigurationKeys.AuthSection].ContainsKey(ConfigurationKeys.Username) ||
                    !data[ConfigurationKeys.AuthSection].ContainsKey(ConfigurationKeys.Password))
                    throw new ApplicationException($"Missing credentials in {amaasConfig}. {ConfigurationKeys.Username} and {ConfigurationKeys.Password} are required.");

                Username = data[ConfigurationKeys.AuthSection][ConfigurationKeys.Username];
                Password = data[ConfigurationKeys.AuthSection][ConfigurationKeys.Password];

                ApiVersion    = apiVersion;
                IsInitialized = true;
            }
        }
    }
}
