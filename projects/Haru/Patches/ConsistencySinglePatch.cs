using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using FilesChecker;

namespace Haru.Patches
{
    public class ConsistencySinglePatch
    {
        public ConsistencySinglePatch()
        {
            var harmony = new Harmony("com.haru.patches.consistencysingle");
            harmony.Patch(GetOriginalMethod(), prefix: GetPatchMethod());
        }

        private MethodBase GetOriginalMethod()
        {
            var types = typeof(ICheckResult).Assembly.GetTypes();
            var type = types.Single(x => x.Name == "ConsistencyController");
            var method = type.GetMethods()
                .Single(x => x.Name == "EnsureConsistencySingle" && x.ReturnType == typeof(Task<ICheckResult>));
            return method;
        }

        private HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = GetType().GetMethod("Patch", flags);
            return new HarmonyMethod(method);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
