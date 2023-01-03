using System.Reflection;

namespace Haru.Client.Models
{
    public interface IPatch
    {
        EPatchType Type { get; }
        string Id { get; }

        MethodBase GetOriginalMethod();
    }
}
