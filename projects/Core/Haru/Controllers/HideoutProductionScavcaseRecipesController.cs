using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class HideoutProductionScavcaseRecipesController : Controller
    {
        private readonly HideoutService _hideoutService;

        public HideoutProductionScavcaseRecipesController()
        {
            _hideoutService = new HideoutService();
        }

        public override void Run(RouterContext context)
        {
            var data = _hideoutService.GetScavcases();
            var body = new ResponseModel<ScavcaseModel[]>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}