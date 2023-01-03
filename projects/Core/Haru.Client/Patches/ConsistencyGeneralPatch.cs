// To allow modders to modify existing EFT files

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Client.Models;
using Haru.Client.Utils;

namespace Haru.Client.Patches
{
    public class ConsistencyGeneralPatch : APatch
    {
        public ConsistencyGeneralPatch()
        {
            Id = "com.haru.client.consistencygeneral";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var flags = PatchConstants.Instance.FlagsPrivateInstance;
            var types = PatchConstants.Instance.EftTypes;
            var type = types.Single(x => x.GetType() == typeof(CommonClientApplication));
            return type.GetMethod("RunFilesChecking", flags);
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }
}
