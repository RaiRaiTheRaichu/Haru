using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Game;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
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
            var body = new ResponseModel<ProfileStatusModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}