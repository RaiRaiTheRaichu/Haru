// ZOutputStream's CanRead and CanWrite must be patched to make Stream.CopyToAsync work.
// While it never reads the destination, it still requires it to be enabled.
// https://referencesource.microsoft.com/mscorlib/system/io/stream.cs.html#162

using System.Reflection;
using ComponentAce.Compression.Libs.zlib;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class ZOutputCanReadPatch : APatch
    {
        public ZOutputCanReadPatch() : base()
        {
            Id = "com.haru.client.zoutputcanread";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            return typeof(ZOutputStream).GetProperty("CanRead").GetGetMethod();
        }

        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}