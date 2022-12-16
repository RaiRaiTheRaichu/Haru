using System.Reflection;

namespace Haru.Patches
{
    public interface IPatch
    {
        EPatchType Type { get; }
        string Id { get; }

        MethodBase GetOriginalMethod();
        MethodInfo GetPatchMethod();
    }
}
