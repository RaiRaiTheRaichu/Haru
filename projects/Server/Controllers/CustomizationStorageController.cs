using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class CustomizationStorageController : Controller
    {
        private readonly IJson _json;
        private readonly IProfileService _service;

        public CustomizationStorageController(
            IZlib zlib,
            IJson json,
            IProfileService profileService,
            IEventBus eventBus) : base(zlib, eventBus)
        {
            _json = json;
            _service = profileService;
        }

        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath.Equals("/client/trading/customization/storage"))
            {
                return;
            }

            var data = _service.GetCustomizationStorageModel();
            var body = new ResponseModel<CustomizationStorageModel>(data);
            var json = _json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}