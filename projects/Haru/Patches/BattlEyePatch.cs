using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;

namespace Haru.Patches
{
    public class BattlEyePatch
    {
        private static readonly PropertyInfo _succeed;

        static BattlEyePatch()
        {
            var harmony = new Harmony("com.haru.patches.battleye");
            var name = "RunValidation";
            var types = typeof(ESideType).Assembly.GetTypes();
            var type = types.Single(x => x?.GetMethod(name) != null);
            _succeed = type.GetProperties().Single(x => x.Name == "Succeed");
            harmony.Patch(type.GetMethod(name), prefix: GetPatchMethod());
        }

        private static HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = typeof(BattlEyePatch).GetMethod("Patch", flags);
            return new HarmonyMethod(method);
        }

        protected static bool Patch(ref Task __result, object __instance)
        {
            _succeed.SetValue(__instance, true);
            __result = Task.CompletedTask;
            return false;
        }
    }
}