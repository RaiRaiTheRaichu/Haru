using HarmonyLib;

namespace Haru.Client
{
    public static class Extensions
    {
        public static void Dispose(this Harmony harmony)
        {
            harmony.UnpatchSelf();
        }
    }
}