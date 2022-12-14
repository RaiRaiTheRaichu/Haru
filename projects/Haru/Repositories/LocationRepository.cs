using Haru.Models.EFT.Location;
using Haru.Databases;

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
            foreach (var location in _database.WorldMap.Locations.Values)
            {
                if (location.Id == locationId)
                {
                    return true;
                }
            }

            return false;
        }

        public LocationModel GetLocation(string locationId)
        {
            foreach (var location in _database.WorldMap.Locations.Values)
            {
                if (location.Id == locationId)
                {
                    return location;
                }
            }

            return default;
        }
    }
}