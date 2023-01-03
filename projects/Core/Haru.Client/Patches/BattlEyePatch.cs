// BE closes the game due to injected assemblies, so it needs to be patched out

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;
using Haru.Client.Utils;

namespace Haru.Client.Patches
{
    public class BattlEyePatch : APatch
    {
        private static PropertyInfo _succeed;

        public BattlEyePatch()
        {
            Id = "com.haru.client.battleye";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "RunValidation";
            var types = PatchConstants.Instance.EftTypes;
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