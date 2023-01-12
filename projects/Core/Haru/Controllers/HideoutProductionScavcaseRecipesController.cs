using System.Threading.Tasks;
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

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/hideout/production/scavcase/recipes";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _hideoutService.GetScavcases();
            var body = new ResponseModel<ScavcaseModel[]>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}