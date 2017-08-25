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
            { AMaaSEnvironment.Dev, new Uri("https://api-dev.amaas.com") },
            { AMaaSEnvironment.Staging, new Uri("https://api-staging.amaas.com") },
            { AMaaSEnvironment.Prod, new Uri("https://api.amaas.com") }
        };
    }
}
