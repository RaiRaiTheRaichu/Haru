using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Http;
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

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/profile/status";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _profileService.GetProfileStatusModel();
            var body = new ResponseModel<StatusModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}