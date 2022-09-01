using Haru.Server.Databases;
using Haru.Server.Repositories;

namespace Haru.Server.Repositories
{
    public static class ResourceRepository
    {
        public static bool HasFile(string url)
        {
            return ResourceDatabase.Files.ContainsKey(url);
        }

        public static string GetFile(string url)
        {
            return ResourceDatabase.Files[url];
        }
    }
}