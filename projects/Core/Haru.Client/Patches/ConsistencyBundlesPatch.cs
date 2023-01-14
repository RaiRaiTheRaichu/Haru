// To allow modders to modify existing EFT files.
// This one is specifically related to bundles.

using System.Reflection;
using System.Threading.Tasks;
using EFT;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class ConsistencyBundlesPatch : APatch
    {
        private readonly PatchHelper _patchHelper;

        public ConsistencyBundlesPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.consistencybundles";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var flags = PatchHelper.PrivateFlags;
            return typeof(TarkovApplication).BaseType
                .GetMethod("DefaultBundleCheck", flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }
}
