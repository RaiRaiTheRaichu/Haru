using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Handbook;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class HandbookTemplatesController : Controller
    {
        private readonly HandbookService _handbookService;

        public HandbookTemplatesController()
        {
            _handbookService = new HandbookService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/handbook/templates";
        }

        public override void Run(RouterContext context)
        {
            var data = _handbookService.GetTemplates();
            var body = new ResponseModel<TemplatesModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}