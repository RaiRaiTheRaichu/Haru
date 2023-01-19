using Haru.Exceptions;
using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Request;
using Haru.Models.EFT.Location;
using Haru.Services;

namespace Haru.Controllers
{
    public class GetLocalLootController : Controller
    {
        private readonly LocationService _locationService;

        public GetLocalLootController()
        {
            _locationService = new LocationService();
        }

        public override void Run(RouterContext context)
        {
            var request = _requestHelper.GetBody(context.Request);
            var info = _json.Deserialize<LocalLootModel>(request);
            var location = info.LocationId;

            if (!_locationService.HasLocation(location))
            {
                throw new LocationNotFoundException(location);
            }

            var data = _locationService.GetLocation(location);
            var body = new ResponseModel<LocationModel>(data);
            var json = _json.Serialize(body);

            SendJson(context, json);
        }
    }
}