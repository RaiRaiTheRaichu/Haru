using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class NotifierChannelCreateController : Controller
    {
        private readonly ControllerHelper _controllerHelper;
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly NotificationService _notificationService;

        public NotifierChannelCreateController()
        {
            _controllerHelper = new ControllerHelper();
            _requestHelper = new RequestHelper();
            _json = new Json();
            _notificationService = new NotificationService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/notifier/channel/create";
        }

        public override async Task Run(RouterContext context)
        {
            var sessionId = _controllerHelper.GetSessionId(context.Request);
            var data = _notificationService.GetNotifier(sessionId);
            var body = new ResponseModel<NotifierModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}