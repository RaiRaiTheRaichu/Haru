using Haru.Helpers;
using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Services;

namespace Haru.Controllers
{
    public class NotifierChannelCreateController : Controller
    {
        private readonly ControllerHelper _controllerHelper;
        private readonly NotificationService _notificationService;

        public NotifierChannelCreateController()
        {
            _controllerHelper = new ControllerHelper();
            _notificationService = new NotificationService();
        }

        public override void Run(RouterContext context)
        {
            var sessionId = _controllerHelper.GetSessionId(context.Request);
            var data = _notificationService.GetNotifier(sessionId);
            var body = new ResponseModel<NotifierModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}