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

        public bool TryGetFile(string path, out string file)
        {
            return _database.Files.TryGetValue(path, out file);
        }
    }
}