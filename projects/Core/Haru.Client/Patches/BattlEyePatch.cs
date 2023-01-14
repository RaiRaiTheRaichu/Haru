// Prevent BE from detecting injected assemblies.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class BattlEyePatch : APatch
    {
        private readonly PatchHelper _patchHelper;
        private static PropertyInfo _succeed;

        public BattlEyePatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.battleye";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
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