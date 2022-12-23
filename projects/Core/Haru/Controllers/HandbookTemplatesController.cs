using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class HandbookTemplatesController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly HandbookService _handbookService;

        public HandbookTemplatesController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _handbookService = new HandbookService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/handbook/templates";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _handbookService.GetTemplates();
            var body = new ResponseModel<TemplatesModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}