#if LOADER_NLOG
using NLog.Targets;

namespace Haru.Loader
{
    [Target("Haru.Loader")]
    public sealed class Target : TargetWithLayout
    {
        public Target()
        {
            HaruInstance.Run();
        }
    }
}
#endif