using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Services;

namespace Haru.Controllers
{
    public class ProfileStatusController : Controller
    {
        private readonly ProfileService _profileService;

        public ProfileStatusController()
        {
            _profileService = new ProfileService();
        }

        public override void Run(RouterContext context)
        {
            var data = _profileService.GetProfileStatusModel();
            var body = new ResponseModel<StatusModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}