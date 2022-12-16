using System.Threading.Tasks;
using Haru.Extensions;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Request;
using Haru.Models.EFT.Location;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class GetLocalLootController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly LocationService _locationService;

        public GetLocalLootController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _locationService = new LocationService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/location/getLocalloot";
        }

        public override async Task Run(RouterContext context)
        {
            var request = await _requestHelper.GetBody(context.Request);
            var info = _json.Deserialize<LocalLootModel>(request);
            var location = info.LocationId;

            if (!_locationService.HasLocation(location))
            {
                throw new LocationNotFoundException(location);
            }

            var data = _locationService.GetLocation(location);
            var body = new ResponseModel<LocationModel>(data);
            var json = _json.Serialize(body);

            await SendJson(context, json);
        }
    }
}