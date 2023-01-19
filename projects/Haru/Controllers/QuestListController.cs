using Haru.Helpers;
using Haru.Http;
using Haru.Models;

namespace Haru.Controllers
{
    public class QuestListController : Controller
    {
        private readonly ControllerHelper _controllerHelper;

        public QuestListController()
        {
            _controllerHelper = new ControllerHelper();
        }

        public override void Run(RouterContext context)
        {
            var body = _controllerHelper.GetEmptyArrayResponse();
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}