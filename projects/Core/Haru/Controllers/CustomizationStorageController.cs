using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Framework.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class CustomizationStorageController : Controller
    {
        private readonly ProfileService _profileService;

        public CustomizationStorageController()
        {
            _profileService = new ProfileService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request)
                == "/client/trading/customization/storage";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _profileService.GetCustomizationStorageModel();
            var body = new ResponseModel<CustomizationStorageModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}