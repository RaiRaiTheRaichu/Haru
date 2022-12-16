#if LOADER_MELON
using MelonLoader;

[assembly: MelonGame("BATTLESTATE GAMES LIMITED", "Escape From Tarkov")]
[assembly: MelonInfo(typeof(Haru.Loader.Mod),HaruInfo.Name, HaruInfo.Version, HaruInfo.Author, HaruInfo.Origin)]

namespace Haru.Loader
{
    public class Mod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            HaruInstance.Run();
        }
    }
}
#endif