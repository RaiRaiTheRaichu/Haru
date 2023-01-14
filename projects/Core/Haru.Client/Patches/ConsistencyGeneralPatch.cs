// To allow modders to modify existing EFT files.
// This one is for all other EFT files.

using System.Reflection;
using System.Threading.Tasks;
using EFT;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class ConsistencyGeneralPatch : APatch
    {
        private readonly PatchHelper _patchHelper;

        public ConsistencyGeneralPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.consistencygeneral";
            Type = EPatchType.Prefix;
            _patchHelper = new PatchHelper();
        }

        protected override MethodBase GetOriginalMethod()
        {
            var flags = PatchHelper.PrivateFlags;
            return typeof(TarkovApplication).BaseType
                .GetMethod("RunFilesChecking", flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }
}
