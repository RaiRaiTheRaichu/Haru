using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Http;
using Haru.Services;
using Haru.Helpers;

namespace Haru.Controllers
{
    public class GameProfileSelectController : Controller
    {
        private readonly ControllerHelper _controllerHelper;
        private readonly NotificationService _notificationService;

        public GameProfileSelectController()
        {
            _controllerHelper = new ControllerHelper();
            _notificationService = new NotificationService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/game/profile/select";
        }

        public override async Task Run(RouterContext context)
        {
            var sessionId = _controllerHelper.GetSessionId(context.Request);
            var data = _notificationService.SelectProfile(sessionId);
            var body = new ResponseModel<ProfileSelectModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}