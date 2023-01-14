using System;
using System.Reflection;
using EFT;

namespace Haru.Client.Helpers
{
    public class PatchHelper
    {
        public readonly Type[] EftTypes;
        public const BindingFlags PrivateFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        public PatchHelper()
        {
            EftTypes = typeof(TarkovApplication).Assembly.GetTypes();
        }
    }
}