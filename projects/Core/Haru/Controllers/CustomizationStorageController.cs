using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
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

        public override void Run(RouterContext context)
        {
            var data = _profileService.GetCustomizationStorageModel();
            var body = new ResponseModel<CustomizationStorageModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}