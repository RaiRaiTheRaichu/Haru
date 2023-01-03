#if LOADER_MELON
using MelonLoader;
using Haru.Framework.DI;
using Haru.Client.Program;

[assembly: MelonGame("BATTLESTATE GAMES LIMITED", "Escape From Tarkov")]
[assembly: MelonInfo(typeof(Haru.Client.Mod),HaruInfo.Name, HaruInfo.Version, HaruInfo.Author, HaruInfo.Origin)]

namespace Haru.Client
{
    public class Mod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            var haru = new HaruInstance();
            haru.Run();
        }
    }
}
#endif