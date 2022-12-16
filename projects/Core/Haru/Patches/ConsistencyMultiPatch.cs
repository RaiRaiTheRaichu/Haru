using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FilesChecker;

namespace Haru.Patches
{
    public class ConsistencyMultiPatch : IPatch
    {
        public string Id { get => "com.haru.patches.consistencymulti"; }
        public EPatchType Type { get => EPatchType.Prefix; }

        public MethodBase GetOriginalMethod()
        {
            var types = typeof(ICheckResult).Assembly.GetTypes();
            var type = types.Single(x => x.Name == "ConsistencyController");
            return type.GetMethods().Single(
                x => x.Name == "EnsureConsistency" &&
                x.ReturnType == typeof(Task<ICheckResult>));
        }

        public MethodInfo GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            return GetType().GetMethod("Patch", flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
