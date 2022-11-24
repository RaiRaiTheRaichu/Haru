using NLog.Targets;

namespace Senko.Example
{
    [Target("Senko.EftData")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            Mod.Run();
        }
    }
}