using System;
using HarmonyLib;
using Haru.Patches;
using Haru.Servers;
using NLog.Targets;

namespace Haru.NLog
{
    [Target("Haru")]
    public sealed class Hook : TargetWithLayout
    {
        // entry point
        public Hook()
        {
            // patch client
            Patch(new BattlEyePatch());
            Patch(new ConsistencyMultiPatch());
            Patch(new ConsistencySinglePatch());
            Patch(new ZOutputCanReadPatch());
            Patch(new ZOutputCanWritePatch());

            // run servers
            ServerManager.GeneralServer.Start();
            ServerManager.NotificationServer.Start();
        }

        public void Patch(IPatch patch)
        {
            var harmony = new Harmony(patch.Id);
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