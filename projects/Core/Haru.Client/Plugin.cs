#if LOADER_BEPINEX
using BepInEx;
using Haru.Framework.DI;
using Haru.Client.Program;

namespace Haru.Client
{
    [BepInPlugin("com.Haru.Client", HaruInfo.Name, HaruInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            var haru = new HaruInstance();
            haru.Run();
        }
    }
}
#endif