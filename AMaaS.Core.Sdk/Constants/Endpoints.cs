using System;
using System.Collections.Generic;
using AMaaS.Core.Sdk.Enums;

namespace AMaaS.Core.Sdk.Constants
{
    public static class Endpoints
    {
        //TODO: Move this to json configuration?
        public static IReadOnlyDictionary<AMaaSEnvironment, Uri> Uris => new Dictionary<AMaaSEnvironment, Uri>
        {
            { AMaaSEnvironment.Local,  new Uri("http://localhost:8000") },
            { AMaaSEnvironment.Default, new Uri("https://api-default.dev.amaas.com") },
            { AMaaSEnvironment.Live, new Uri("https://api.amaas.com") }
        };
    }
}
