using BepInEx;

namespace Senko.LangPack
{
    [BepInPlugin("com.senko.langpack", "Senko.LangPack", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            Mod.Run();
        }
    }
}