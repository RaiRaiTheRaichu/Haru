using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Location;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;

        public LocationController()
        {
            _locationService = new LocationService();
        }

        public override void Run(RouterContext context)
        {
            var data = _locationService.GetWorldMap();
            var body = new ResponseModel<WorldMapModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}