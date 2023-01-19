// Prevent BE from detecting injected assemblies.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class BattlEyePatch : APatch
    {
        private static PropertyInfo _succeed;

        public BattlEyePatch() : base()
        {
            Id = "com.haru.client.battleye";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "RunValidation";
            var type = _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null);

            // find succeed property
            _succeed = type.GetProperties().Single(x => x.Name == "Succeed");

            // find method
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