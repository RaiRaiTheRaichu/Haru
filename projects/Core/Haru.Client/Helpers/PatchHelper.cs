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

        public PatchHelper()
        {
            EftTypes = typeof(ESideType).Assembly.GetTypes();
        }
    }
}