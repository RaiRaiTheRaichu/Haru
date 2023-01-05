// Change protocols to non-SSL variants.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class HttpProtocolPatch : APatch
    {
        private PatchHelper _patchHelper;
        private static readonly Dictionary<ETransportProtocolType, string> _protocols;

        static HttpProtocolPatch()
        {
            _protocols = new Dictionary<ETransportProtocolType, string>()
            {
                { ETransportProtocolType.HTTPS, "http://" },
                { ETransportProtocolType.WSS, "ws://" }
            };
        }

        public HttpProtocolPatch(PatchHelper patchHelper)
        {
            Id = "com.haru.client.httpprotocol";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "CreateFromLegacyParams";
            return _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null)
                .GetProperty("TransportPrefixes").GetGetMethod();
        }

        protected static bool Patch(ref Dictionary<ETransportProtocolType, string> __result)
        {
            __result = _protocols;
            return false;
        }
    }
}