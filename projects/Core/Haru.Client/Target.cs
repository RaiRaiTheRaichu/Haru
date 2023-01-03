#if LOADER_NLOG
using NLog.Targets;
using Haru.Framework.DI;
using Haru.Client.Program;

namespace Haru.Client
{
    [Target("Haru.Client")]
    public sealed class Target : TargetWithLayout
    {
        public Target()
        {
            var haru = new HaruInstance();
            haru.Run();
        }
    }
}
#endif