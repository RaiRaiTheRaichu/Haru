// In order to allow usage of self-signed certificates

using System.Reflection;
using UnityEngine.Networking;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class SslCertificateTexturePatch : APatch
    {
        public SslCertificateTexturePatch()
        {
            Id = "com.haru.client.sslcertificatetexture";
            Type = EPatchType.Postfix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            return typeof(UnityWebRequestTexture).GetMethod(
                nameof(UnityWebRequestTexture.GetTexture),
                new[] { typeof(string) });
        }

        protected static void Patch(UnityWebRequest __result)
        {
            __result.certificateHandler = new FakeCertificateHandler();
            __result.disposeCertificateHandlerOnDispose = true;
            __result.timeout = 15000;
        }
    }
}