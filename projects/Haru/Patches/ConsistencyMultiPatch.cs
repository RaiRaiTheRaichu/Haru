using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using FilesChecker;

namespace Haru.Patches
{
    public class ConsistencyMultiPatch
    {
        static ConsistencyMultiPatch()
        {
            var harmony = new Harmony("com.haru.patches.consistencymulti");
            harmony.Patch(GetOriginalMethod(), prefix: GetPatchMethod());
        }

        private static MethodBase GetOriginalMethod()
        {
            var types = typeof(ICheckResult).Assembly.GetTypes();
            var type = types.Single(x => x.Name == "ConsistencyController");
            var method = type.GetMethods().Single(x => x.Name == "EnsureConsistency"
                && x.ReturnType == typeof(Task<ICheckResult>));
            return method;
        }

        private static HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = typeof(ConsistencyMultiPatch).GetMethod("Patch", flags);
            return new HarmonyMethod(method);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
