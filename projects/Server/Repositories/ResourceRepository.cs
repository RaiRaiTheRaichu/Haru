using Haru.Databases;
using Haru.Repositories;

namespace Haru.Server.Repositories
{
    public static class ResourceRepository
    {
        public bool HasFile(string url)
        {
            return ResourceDatabase.Files.ContainsKey(url);
        }

        public string GetFile(string url)
        {
            return ResourceDatabase.Files[url];
        }

        public string[] GetFileNames()
        {
            return ResourceDatabase.FileNames;
        }
    }
}