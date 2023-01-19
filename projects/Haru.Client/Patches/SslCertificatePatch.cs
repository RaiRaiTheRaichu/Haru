// Disable certificate checking.

using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class SslCertificatePatch : APatch
    {
        public SslCertificatePatch() : base()
        {
            Id = "com.haru.client.sslcertificate";
            Type = EPatchType.Prefix;
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