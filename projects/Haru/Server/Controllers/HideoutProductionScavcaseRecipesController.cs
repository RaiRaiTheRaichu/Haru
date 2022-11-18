using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Hideout;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class HideoutProductionScavcaseRecipesController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/hideout/production/scavcase/recipes";
        }

        public override async Task Run(RouterContext context)
        {
            var data = HideoutService.GetScavcases();
            var body = new ResponseModel<ScavcaseModel[]>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}