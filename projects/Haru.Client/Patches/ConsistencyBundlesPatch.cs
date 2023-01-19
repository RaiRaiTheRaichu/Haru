// To allow modders to modify existing EFT files.
// This one is specifically related to bundles.

using System.Reflection;
using System.Threading.Tasks;
using EFT;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class ConsistencyBundlesPatch : APatch
    {
        public ConsistencyBundlesPatch() : base()
        {
            Id = "com.haru.client.consistencybundles";
            Type = EPatchType.Prefix;
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
