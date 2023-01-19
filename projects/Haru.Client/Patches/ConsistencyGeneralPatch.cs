// To allow modders to modify existing EFT files.
// This one is for all other EFT files.

using System.Reflection;
using System.Threading.Tasks;
using EFT;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class ConsistencyGeneralPatch : APatch
    {
        public ConsistencyGeneralPatch() : base()
        {
            Id = "com.haru.client.consistencygeneral";
            Type = EPatchType.Prefix;
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
