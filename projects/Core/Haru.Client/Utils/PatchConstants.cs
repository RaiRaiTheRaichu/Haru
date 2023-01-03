using System.Reflection;

namespace Haru.Client.Utils
{
    public class PatchConstants
    {
        public readonly Type[] EftTypes;
        public const BindingFlags FlagsPrivateInstance =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        private static PatchConstants _instance;
        public static PatchConstants Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PatchConstants();
                }

                return _instance;
            }
        }

        public PatchConstants()
        {
            EftTypes = typeof(ESideType).Assembly.GetTypes();
        }
    }
}