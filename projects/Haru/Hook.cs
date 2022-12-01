using Haru.Patches;
using Haru.Servers;
using NLog.Targets;

namespace Haru
{
    [Target("Haru")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            // patch client
            new BattlEyePatch();
            new ConsistencyMultiPatch();
            new ConsistencySinglePatch();
            new ZOutputStreamPatch();

            // run servers
            ServerManager.GeneralServer.Start();
            ServerManager.NotificationServer.Start();
        }
    }
}