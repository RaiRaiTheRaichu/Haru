using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Models.EFT;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class NotifierChannelCreateController : Controller
    {
        public override async Task Run(RouterRequest routerRequest)
        {
            if (!routerRequest.request.Url.LocalPath
                .Equals("/client/notifier/channel/create"))
            {
                return;
            }

            var sessionId = RequestHelper.GetSessionId(routerRequest.request);
            var data = NotifierService.GetNotifier(sessionId);
            var body = new ResponseModel<NotifierServerModel>(data);
            var json = Json.Serialize(body);
            await SendJson(routerRequest.response, json);
        }
    }
}