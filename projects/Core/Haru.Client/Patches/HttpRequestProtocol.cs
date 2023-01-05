// Change request protocol from HTTPS to HTTP.
// Ported from SPT-Aki, originally written by Terkoiz.

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

        public HttpRequestPatch(PatchHelper patchHelper)
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
            // opcode to find
            var searchCode = new CodeInstruction(OpCodes.Ldstr, "https://");

            // find instruction
            var codes = new List<CodeInstruction>(instructions);
            var searchIndex = -1;

            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == searchCode.opcode && codes[i].operand == searchCode.operand)
                {
                    searchIndex = i;
                    break;
                }
            }

            if (searchIndex == -1)
            {
                // error: cannot find reference code.
                return instructions;
            }

            // change opcode
            codes[searchIndex] = new CodeInstruction(OpCodes.Ldstr, "http://");

            // apply changes
            return codes.AsEnumerable();
        }
    }
}