using NLog.Targets;

namespace Senko.Example
{
    [Target("Senko.Langpack")]
    public sealed class Hook : TargetWithLayout
    {
        public Hook()
        {
            Mod.Run();
        }
    }
}