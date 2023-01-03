using System;
using System.Linq;
using System.Reflection;

namespace Haru.Client.Helpers
{
    public class PatchHelper
    {
        public readonly Type[] EftTypes;
        public const BindingFlags PrivateFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
        public const BindingFlags PublicFlags = 
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;

        public PatchHelper()
        {
            EftTypes = typeof(ESideType).Assembly.GetTypes();
        }

        public MethodBase FindMethod(string name, bool isPrivate = false)
        {
            var flags = (isPrivate) ? PrivateFlags : PublicFlags;
            return EftTypes.Single(x => x?.GetMethod(name, flags) != null)
                .GetMethod(name, flags);
        }
    }
}