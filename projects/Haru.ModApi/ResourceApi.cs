using System.Reflection;
using Haru.Utils;

namespace Haru.ModApi
{
    public static class ResourceApi
    {
        private static readonly Resource _resource;

        static ResourceApi()
        {
            _resource = new Resource();
        }

        public static void EnableResourceLoading(Assembly assembly)
        {
            _resource.RegisterAssembly(assembly);
        }

        public static string GetText(string key)
        {
            return _resource.GetText(key);
        }

        public static byte[] GetData(string key)
        {
            return _resource.GetData(key);
        }
    }
}
