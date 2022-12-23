using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class ProfileStatusController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly ProfileService _profileService;

        public ProfileStatusController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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