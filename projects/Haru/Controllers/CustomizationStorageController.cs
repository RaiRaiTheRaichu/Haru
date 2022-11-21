using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Helpers;
using Haru.Http;
using Haru.Services;
using Haru.Utils;

namespace Haru.Controllers
{
    public class CustomizationStorageController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/trading/customization/storage";
        }

        public override async Task Run(RouterContext context)
        {
            var data = ProfileService.GetCustomizationStorageModel();
            var body = new ResponseModel<CustomizationStorageModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}