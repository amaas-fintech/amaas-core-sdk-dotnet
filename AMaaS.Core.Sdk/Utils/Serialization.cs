using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMaaS.Core.Sdk.Models.Utils
{
    public static class SerializationUtils
    {
        public static JsonSerializerSettings SnakeCaseSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() },
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };

        public static string ToJson<TModel>(TModel model) where TModel : AMaaSModel => JsonConvert.SerializeObject(model, SnakeCaseSettings);
        public static TModel FromJson<TModel>(string json) where TModel : AMaaSModel => JsonConvert.DeserializeObject<TModel>(json, SnakeCaseSettings);
    }
}
