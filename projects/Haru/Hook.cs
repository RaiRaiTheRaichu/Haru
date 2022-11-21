using Haru.Patches;
using Haru.Servers;
using Haru.Utils;
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

            // run server
            Resource.RegisterAssembly(typeof(Resource).Assembly);
            ServerManager.GeneralServer.Start();
            ServerManager.NotificationServer.Start();
        }
    }
}