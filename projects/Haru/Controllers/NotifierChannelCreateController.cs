using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
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