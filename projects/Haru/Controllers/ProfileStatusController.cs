using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Profile;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class ProfileStatusController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/profile/status";
        }

        public override async Task Run(RouterContext context)
        {
            var data = ProfileService.GetProfileStatusModel();
            var body = new ResponseModel<StatusModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}