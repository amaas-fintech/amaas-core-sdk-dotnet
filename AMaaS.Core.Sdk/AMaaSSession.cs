using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Amazon;
using Amazon.Extensions.CognitoAuthentication;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web;
using AMaaS.Core.Sdk.Models.Utils;
using AMaaS.Core.Sdk.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace AMaaS.Core.Sdk
{
    public class AMaaSSession
    {
        #region Fields

        private DateTime   _lastAuthenticatedTime;
        private HttpClient _httpClient;
        private Task       _initialization;

        #endregion

        #region Properties

        public IAMaaSConfiguration Config { get; }
        public bool   IsAuthenticated => !string.IsNullOrEmpty(IdToken);
        public string IdToken { get; private set; }
        public JwtSecurityToken JwtToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public AMaaSSession(IAMaaSConfiguration config)
        {
            Config = config;
            _httpClient = new HttpClient();

            if (_initialization == null)
                _initialization = LoginAsync();
        }

        #endregion

        #region Methods

        private async Task LoginAsync()
        {
            var region   = RegionEndpoint.GetBySystemName(Config?.AwsRegion);
            var provider = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), region);
            var userPool = new CognitoUserPool(Config.CognitoPoolId, Config.CognitoClientId, provider);
            var user     = new CognitoUser(Config?.Username, Config?.CognitoClientId, userPool, provider);

            var context = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
            {
                Password = Config?.Password
            }).ConfigureAwait(false);

            _lastAuthenticatedTime = DateTime.Now;
            IdToken                = context.AuthenticationResult.IdToken;
            JwtToken               = new JwtSecurityTokenHandler().ReadJwtToken(IdToken);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(IdToken);
        }

        public async Task<string> GetTokenAttribute(string attributeName)
        {
            await _initialization;

            if (JwtToken == null)
                return null;

            object attribute = null;
            return JwtToken?.Payload?.TryGetValue(attributeName, out attribute) ?? false
                        ? attribute.ToString() : null;
        }

        public async Task<TResult> GetAsync<TResult>(string route, Dictionary<string,string> queryParams = null)
        {
            await _initialization;

            var uri = BuildUri(route, queryParams);
            var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var jsonBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResult>(jsonBody, SerializationUtils.SnakeCaseSettings);
        }

        public async Task<TResult> PostAsync<TData, TResult>(string route, Dictionary<string,string> queryParams, TData data)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods

        private string BuildUri(string route, Dictionary<string, string> queryParams)
        {
            var address  = $"{Config?.Endpoint}/{route}";
            var builder  = new UriBuilder(address);
            builder.Port = -1;
            if (queryParams != null)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                foreach (var kvp in queryParams)
                {
                    query[kvp.Key] = kvp.Value;
                }
                builder.Query = query.ToString();
            }
            return builder.ToString();
        }
        #endregion
    }
}
