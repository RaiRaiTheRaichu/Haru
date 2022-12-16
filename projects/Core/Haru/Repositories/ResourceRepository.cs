using Haru.Databases;

namespace Haru.Repositories
{
    public class ResourceRepository
    {
        private readonly Database _database;

        public ResourceRepository()
        {
            _database = Database.Instance;
        }

        public bool HasFile(string url)
        {
            return _database.Files.ContainsKey(url);
        }

        public string GetFile(string url)
        {
            return _database.Files[url];
        }
    }
}