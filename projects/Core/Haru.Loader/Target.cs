#if LOADER_NLOG
using NLog.Targets;
using Haru.Framework.DI;

namespace Haru.Loader
{
    [Target("Haru.Loader")]
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