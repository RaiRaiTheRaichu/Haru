// To allow modders to modify existing EFT files.
// This one is specifically related to bundles.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class ConsistencyBundlesPatch : APatch
    {
        private PatchHelper _patchHelper;

        public ConsistencyBundlesPatch(PatchHelper patchHelper)
        {
            Id = "com.haru.client.consistencybundles";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "DefaultBundleCheck";
            var flags = PatchHelper.PrivateFlags;
            return _patchHelper.EftTypes.Single(x => x?.GetMethod(name, flags) != null)
                .GetMethod(name, flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }
}
