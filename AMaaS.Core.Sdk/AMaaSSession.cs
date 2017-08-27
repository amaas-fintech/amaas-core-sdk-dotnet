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

        #endregion

        #region Properties

        public IAMaaSConfiguration Config { get; }
        public bool   IsAuthenticated => !string.IsNullOrEmpty(IdToken);
        public string IdToken { get; private set; }
        public Task Initialization { get; private set; }
        public JwtSecurityToken JwtToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public AMaaSSession(IAMaaSConfiguration config)
        {
            Config      = config;
            _httpClient = new HttpClient();

            if (Initialization == null)
                Initialization = LoginAsync();
        }

        #endregion

        #region Methods

        private async Task LoginAsync(string username = null, string password = null)
        {
            var region   = RegionEndpoint.GetBySystemName(Config?.AwsRegion);
            var provider = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), region);
            var userPool = new CognitoUserPool(Config.CognitoPoolId, Config.CognitoClientId, provider);
            var user     = new CognitoUser(username ?? Config?.Username, Config?.CognitoClientId, userPool, provider);

            var context = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
            {
                Password = password ?? Config?.Password
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
            await Initialization;

            if (JwtToken == null)
                return null;

            object attribute = null;
            return JwtToken?.Payload?.TryGetValue(attributeName, out attribute) ?? false
                        ? attribute.ToString() : null;
        }

        public async Task<TResult> GetAsync<TResult>(string route, Dictionary<string,string> queryParams = null)
        {
            await Initialization;

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
                //There's currently a bug in .NET standard version of HttpUtility
                //uncomment this once it has been fixed
                //var query = HttpUtility.ParseQueryString(string.Empty);
                var query = new System.Collections.Specialized.NameValueCollection();
                foreach (var kvp in queryParams)
                {
                    query[kvp.Key] = kvp.Value;
                }
                builder.Query = ToQueryString(query);
            }
            return builder.ToString();
        }

        [Obsolete("Temporary helper method until HttpUtility.ParseQueryString gets fixed in .NET Standard")]
        private string ToQueryString(System.Collections.Specialized.NameValueCollection query)
        {
            var items = new List<string>();

            foreach (string name in query)
                items.Add(string.Concat(name, "=", System.Net.WebUtility.UrlEncode(query[name])));

            return string.Join("&amp;", items.ToArray());
        }
        #endregion
    }
}
