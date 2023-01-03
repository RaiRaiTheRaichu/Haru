using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class BattlEyePatch : IPatch
    {
        public string Id { get => "com.Haru.Client.Patches.battleye"; }
        public EPatchType Type { get => EPatchType.Prefix; }
        private static PropertyInfo _succeed;

        public MethodBase GetOriginalMethod()
        {
            var name = "RunValidation";
            var types = typeof(ESideType).Assembly.GetTypes();
            var type = types.Single(x => x?.GetMethod(name) != null);
            _succeed = type.GetProperties().Single(x => x.Name == "Succeed");
            return type.GetMethod(name);
        }

        protected static bool Patch(ref Task __result, object __instance)
        {
            _succeed.SetValue(__instance, true);
            __result = Task.CompletedTask;
            return false;
        }
    }
}