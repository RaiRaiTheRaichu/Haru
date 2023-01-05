// Fix url protocol (which somehow has https://http:// in it).

using System.Linq;
using System.Reflection;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class HttpUrlPatch : APatch
    {
        private PatchHelper _patchHelper;

        public HttpUrlPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.httpurl";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "CreateFromLegacyParams";
            return _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null)
                .GetMethod(name);
        }

        protected static bool Patch(ref object[] __args, MethodBase __originalMethod)
        {
            // we're dealing here with an obfuscated object (GStruct22 legacyParams),
            // so we gotta use reflection to get the property.
            var obj = __args[0];
            var type = __originalMethod.GetParameters()[0].GetType();
            var url = type.GetProperties().Single(x => x.Name == "Url");

            // strip protocols
            var val = (string)url.GetValue(obj);
            url.SetValue(obj, val.Replace("https://", "").Replace("http://", ""));

            // run HttpProtocolPatch
            return true;
        }
    }
}