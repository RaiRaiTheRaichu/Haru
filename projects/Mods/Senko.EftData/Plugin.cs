using BepInEx;

namespace Senko.EftData
{
    [BepInPlugin("com.senko.eftdata", "Senko.EftData", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            Mod.Run();
        }
    }
}