using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Trader;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class TraderSettingsController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly TraderService _traderService;

        public TraderSettingsController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _traderService = new TraderService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/trading/api/traderSettings";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _traderService.GetTraders();
            var body = new ResponseModel<TraderModel[]>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}