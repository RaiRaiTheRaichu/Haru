using NLog.Targets;

namespace Senko.Example
{
    [Target("Senko.Example")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            Mod.Run();
        }
    }
}