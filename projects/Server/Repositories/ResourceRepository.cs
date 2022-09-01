using Haru.Databases;
using Haru.Repositories;

namespace Haru.Server.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IResourceDatabase _database;

        public ResourceRepository(IResourceDatabase database)
        {
            _database = database;
        }

        public bool HasFile(string url)
        {
            return _database.Files.ContainsKey(url);
        }

        public string GetFile(string url)
        {
            return _database.Files[url];
        }

        public string[] GetFileNames()
        {
            return _database.FileNames;
        }
    }
}