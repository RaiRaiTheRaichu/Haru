#if LOADER_BEPINEX
using BepInEx;
using Haru.Framework.DI;

namespace Haru.Loader
{
    [BepInPlugin("com.haru.loader", HaruInfo.Name, HaruInfo.Version)]
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