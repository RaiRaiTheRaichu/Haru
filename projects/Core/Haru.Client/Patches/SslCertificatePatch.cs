// Disable certificate checking.

using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class SslCertificatePatch : APatch
    {
        private PatchHelper _patchHelper;

        public SslCertificatePatch(PatchHelper patchHelper)
        {
            Id = "com.haru.client.sslcertificate";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            return _patchHelper.EftTypes.Single(x => x.BaseType == typeof(CertificateHandler))
				.GetMethod("ValidateCertificate");
        }

        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}