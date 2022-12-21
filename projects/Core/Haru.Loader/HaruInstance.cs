using System;
using HarmonyLib;
using Haru.Patches;
using Haru.Servers;

namespace Haru.Loader
{
    public class HaruInstance
    {
        public static void Run()
        {
            // patch client
            Patch(new BattlEyePatch());
            Patch(new ConsistencyMultiPatch());
            Patch(new ConsistencySinglePatch());
            Patch(new ZOutputCanReadPatch());
            Patch(new ZOutputCanWritePatch());

            // run servers
            GeneralServer.Instance.Start();
            NotificationServer.Instance.Start();
        }

        private static void Patch(IPatch patch)
        {
            var harmony = new HarmonyLib.Harmony(patch.Id);
            var method = new HarmonyMethod(patch.GetPatchMethod());

            switch (patch.Type)
            {
                case EPatchType.Prefix:
                    harmony.Patch(patch.GetOriginalMethod(), prefix: method);
                    return;

                default:
                    throw new NotImplementedException("Patch type");
            }
        }
    }
}
