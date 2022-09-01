using Haru.Patches;
using Haru.Server;
using NLog.Targets;

namespace Haru
{
    [Target("Haru")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            PatchClient();
            StartServer();
        }

        private void PatchClient()
        {
            new BattlEyePatch();
        }

        private void StartServer()
        {
            ServerManager.Server.Start();
        }
    }
}