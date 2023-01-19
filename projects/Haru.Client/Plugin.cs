using BepInEx;
using Haru.Client.Helpers;
using Haru.Client.Patches;

namespace Haru.Client
{
    [BepInPlugin("com.haru.client", "Haru", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            RunPatcher();
            RunServer();
        }

        public void RunServer()
        {
            HookHelper.Object.GetOrAddComponent<ProcessHelper>();
        }

        public void RunPatcher()
        {
            var patchHelper = new PatchHelper();

            new BattlEyePatch(patchHelper).Enable();
            new ConsistencyGeneralPatch(patchHelper).Enable();
            new ConsistencyBundlesPatch(patchHelper).Enable();
            new SslCertificatePatch(patchHelper).Enable();
        }
    }
}