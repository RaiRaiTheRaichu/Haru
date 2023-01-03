// To allow modders to modify existing EFT files.
// This one is for all other EFT files.

using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class ConsistencyGeneralPatch : APatch
    {
        private PatchHelper _patchHelper;

        public ConsistencyGeneralPatch(PatchHelper patchHelper)
        {
            Id = "com.haru.client.consistencygeneral";
            Type = EPatchType.Prefix;
            _patchHelper = new PatchHelper();
        }

        protected override MethodBase GetOriginalMethod()
        {
            return _patchHelper.FindMethod("RunFilesChecking", true);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }
}
