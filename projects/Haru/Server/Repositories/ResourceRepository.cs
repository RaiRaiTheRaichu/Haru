using Haru.Server.Databases;

namespace Haru.Server.Repositories
{
    public static class ResourceRepository
    {
        public static bool HasFile(string url)
        {
            return Database.Files.ContainsKey(url);
        }

        public static string GetFile(string url)
        {
            return Database.Files[url];
        }
    }
}