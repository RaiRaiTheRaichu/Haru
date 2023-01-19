using System.Linq;
using Haru.Databases;
using Haru.Models.EFT.Location;

namespace Haru.Repositories
{
    public class LocationRepository
    {
        private readonly Database _database;

        public LocationRepository()
        {
            _database = Database.Instance;
        }

        public WorldMapModel GetWorldMap()
        {
            return _database.WorldMap;
        }

        public bool HasLocation(string locationId)
        {
            return _database.WorldMap.Locations.Values.Any(x => x.Id == locationId);
        }

        public LocationModel GetLocation(string locationId)
        {
            return _database.WorldMap.Locations.Values.FirstOrDefault(x => x.Id == locationId);
        }
    }
}