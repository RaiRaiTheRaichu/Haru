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
        private static FieldInfo _prefixes;
        private static readonly Dictionary<ETransportProtocolType, string> _protocols;

        static HttpProtocolPatch()
        {
            _protocols = new Dictionary<ETransportProtocolType, string>()
            {
                { ETransportProtocolType.HTTPS, "http://" },
                { ETransportProtocolType.WSS, "ws://" }
            };
        }

        public HttpProtocolPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.httpprotocol";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "CreateFromLegacyParams";
            var type = _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null);

            // get field
            _prefixes = type.GetField("TransportPrefixes");

            // get hook method
            return type.GetMethod(name);
        }

        protected static bool Patch(ref object __instance)
        {
            _prefixes.SetValue(__instance, _protocols);
            return false;
        }
    }
}