using Haru.Models.EFT.Location;
using Haru.Repositories;

namespace Haru.Services
{
    public class LocationService
    {
        private readonly LocationRepository _locationRepository;

        public LocationService()
        {
            _locationRepository = new LocationRepository();
        }

        public WorldMapModel GetWorldMap()
        {
            return _locationRepository.GetWorldMap();
        }

        public bool HasLocation(string locationId)
        {
            return _locationRepository.HasLocation(locationId);
        }

        public LocationModel GetLocation(string locationId)
        {
            return _locationRepository.GetLocation(locationId);
        }
    }
}