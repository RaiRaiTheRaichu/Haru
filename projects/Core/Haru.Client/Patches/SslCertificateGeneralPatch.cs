// In order to allow usage of self-signed certificates

using System.Linq;
using System.Reflection;
using UnityEngine.Networking;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class SslCertificateGeneralPatch : APatch
    {
        public SslCertificateGeneralPatch()
        {
            Id = "com.haru.client.sslcertificategeneral";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            var types = typeof(ESideType).Assembly.GetTypes();
            var type = types.Single(x => x.BaseType == typeof(CertificateHandler));
            return type.GetMethod("ValidateCertificate", flags);
        }

        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}