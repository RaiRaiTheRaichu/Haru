// Change request protocol from HTTPS to HTTP.
// Ported from SPT-Aki, originally written by Terkoiz.
// Thanks to Bepis for helping me port this.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Haru.Client.Models;
using Haru.Client.Helpers;

namespace Haru.Client.Patches
{
    public class HttpRequestPatch : APatch
    {
        private readonly PatchHelper _patchHelper;

        public HttpRequestPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.httprequest";
            Type = EPatchType.Transpile;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "CreateFromLegacyParams";
            return _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null)
                .GetMethod(name);
        }

        protected static IEnumerable<CodeInstruction> Patch(ILGenerator generator, IEnumerable<CodeInstruction> instructions)
        {
            /* 
             * ```
             * Token: 0x06002012 RID: 8210 RVA: 0x000AFDAC File Offset: 0x000ADFAC
             * public static \uE2C2.CreateFromLegacyParams(\uE2C3 legacyParams)
             * {
             *     ldarg.0 NULL
             *     ldfld string ::Url
             *     ldc.i4 11698
             *     call static string ::(int )
             *     ldstr ""
             *     callvirt string string::Replace(string oldValue, string newValue)
             *     ldc.i4.1 NULL
             *     ...
             * }
             * ```
             * Our target is the 4th instruction.
             * ```
             * ldc.i4 11698
             * call static string ::(int )
             * ```
             * This is an obfuscated string, the real instruction is:
             * ```
             * ldstr "https://"
             * ```
             * We want to replace this with the following:
             * ```
             * ldstr "http://"
             * ```
             * Problem is that the original instruction consumes i4 from the stack (ldc.i4 11698).
             * To handle this, we simply have to patch it out:
             * ```
             * nop
             * ldstr "http://"
             * ```
             */

            // change opcode
            var codes = new List<CodeInstruction>(instructions);
            codes[2] = new CodeInstruction(OpCodes.Nop);
            codes[3] = new CodeInstruction(OpCodes.Ldstr, "http://");

            // apply changes
            return codes.AsEnumerable();
        }
    }
}