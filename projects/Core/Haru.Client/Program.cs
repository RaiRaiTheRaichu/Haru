using Haru.Client.Helpers;
using Haru.Client.Patches;

namespace Haru.Client
{
    class Program
    {
        public void SetupPatches()
        {
            var patchHelper = new PatchHelper();

            new BattlEyePatch(patchHelper).Enable();
            new ConsistencyGeneralPatch(patchHelper).Enable();
            new ConsistencyBundlesPatch(patchHelper).Enable();
            new SslCertificatePatch(patchHelper).Enable();
            new ZOutputCanReadPatch().Enable();
            new ZOutputCanWritePatch().Enable();
        }
    }
}