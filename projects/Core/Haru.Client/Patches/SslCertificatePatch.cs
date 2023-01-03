// In order to allow usage of self-signed certificates.

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
            return _patchHelper.FindMethod("ValidateCertificate");
        }

        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}