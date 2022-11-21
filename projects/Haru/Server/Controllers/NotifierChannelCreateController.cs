using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
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
            var data = NotificationService.GetNotifier(sessionId);
            var body = new ResponseModel<NotifierModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}