using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;

namespace Haru.Patches
{
    public class BattlEyePatch
    {
        private static PropertyInfo _succeed;

        public BattlEyePatch()
        {
            var harmony = new Harmony("com.haru.patches.battleye");
            harmony.Patch(GetOriginalMethod(), prefix: GetPatchMethod());
        }

        private MethodBase GetOriginalMethod()
        {
            var name = "RunValidation";
            var types = typeof(ESideType).Assembly.GetTypes();
            var type = types.Single(x => x?.GetMethod(name) != null);
            _succeed = type.GetProperties().Single(x => x.Name == "Succeed");
            return type.GetMethod(name);
        }

        private HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = GetType().GetMethod("Patch", flags);
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