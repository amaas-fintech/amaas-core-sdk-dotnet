using AMaaS.Core.Sdk.Constants;
using AMaaS.Core.Sdk.Contracts;
using AMaaS.Core.Sdk.Enums;
using System.Collections.Generic;

namespace AMaaS.Core.Sdk
{
    public abstract class AMaaSInterfaceBase : IAMaaSInterface
    {
        #region Properties

        public abstract string EndpointType { get; }
        public string AuthorizationToken => Session?.AuthorizationToken;
        protected AMaaSSession Session { get; }

        #endregion

        #region Constructor

        public AMaaSInterfaceBase(AMaaSSession session)
        {
            Session = session;
        }

        #endregion
    }
}
