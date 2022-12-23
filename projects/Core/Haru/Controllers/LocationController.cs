using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Location;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class LocationController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly LocationService _locationService;

        public LocationController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _locationService = new LocationService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/locations";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _locationService.GetWorldMap();
            var body = new ResponseModel<WorldMapModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}