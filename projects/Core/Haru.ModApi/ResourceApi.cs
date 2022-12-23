using System.Reflection;
using System.Threading.Tasks;
using Haru.Framework.Utils;

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

        public static async Task<string> GetText(string key)
        {
            return await _resource.GetText(key);
        }

        public static async Task<byte[]> GetData(string key)
        {
            return await _resource.GetData(key);
        }
    }
}
