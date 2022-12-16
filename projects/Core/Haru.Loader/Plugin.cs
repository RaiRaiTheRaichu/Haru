#if LOADER_BEPINEX
using BepInEx;

namespace Haru.Loader
{
    [BepInPlugin("com.haru.loader", HaruInfo.Name, HaruInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            HaruInstance.Run();
        }
    }
}
#endif