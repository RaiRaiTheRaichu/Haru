using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class HandbookTemplatesController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/handbook/templates";
        }

        public override async Task Run(RouterContext context)
        {
            var data = HandbookService.GetTemplates();
            var body = new ResponseModel<TemplatesModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}