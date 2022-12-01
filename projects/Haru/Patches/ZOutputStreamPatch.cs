// ZOutputStream.CanRead must be patched to make Stream.CopyToAsync work.
// While it never reads the destination, it still requires it to be enabled.
// https://referencesource.microsoft.com/mscorlib/system/io/stream.cs.html#162

using System.Reflection;
using ComponentAce.Compression.Libs.zlib;
using HarmonyLib;

namespace Haru.Patches
{
    public class ZOutputStreamPatch
    {
        public ZOutputStreamPatch()
        {
            var harmony = new Harmony("com.haru.patches.zoutputstream");
            harmony.Patch(GetCanReadMethod(), prefix: GetPatchMethod());
            harmony.Patch(GetCanWriteMethod(), prefix: GetPatchMethod());
        }

        private MethodBase GetCanReadMethod()
        {
            return typeof(ZOutputStream).GetProperty("CanRead").GetGetMethod();
        }

        private MethodBase GetCanWriteMethod()
        {
            return typeof(ZOutputStream).GetProperty("CanWrite").GetGetMethod();
        }

        private HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = GetType().GetMethod("Patch", flags);
            return new HarmonyMethod(method);
        }

        protected static bool Patch(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}