using System.Reflection;
using Haru.Utils;

namespace Haru.ModApi
{
    public static class ResourceApi
    {
        public static void EnableResourceLoading(Assembly assembly)
        {
            Resource.RegisterAssembly(assembly);
        }

        public static string GetText(string key)
        {
            return Resource.GetText(key);
        }

        public static byte[] GetData(string key)
        {
            return Resource.GetData(key);
        }
    }
}
