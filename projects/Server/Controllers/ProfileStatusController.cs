using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class ProfileStatusController : Controller
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath
                .Equals("/client/profile/status"))
            {
                // throw exception
                return;
            }

            var data = ProfileService.GetProfileStatusModel();
            var body = new ResponseModel<ProfileStatusModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}