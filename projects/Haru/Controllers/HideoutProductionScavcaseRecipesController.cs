using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class HideoutProductionScavcaseRecipesController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly HideoutService _hideoutService;

        public HideoutProductionScavcaseRecipesController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
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