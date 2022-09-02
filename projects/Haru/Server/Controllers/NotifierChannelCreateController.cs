using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class NotifierChannelCreateController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/notifier/channel/create";
        }

        public override async Task Run(RouterContext context)
        {
            var sessionId = RequestHelper.GetSessionId(context.Request);
            var data = NotifierService.GetNotifier(sessionId);
            var body = new ResponseModel<NotifierServerModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}