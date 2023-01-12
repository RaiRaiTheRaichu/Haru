using BepInEx;

namespace Haru.Client
{
    [BepInPlugin("com.haru.client", "Haru", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            var program = new Program();
            program.SetupPatches();
        }
    }
}