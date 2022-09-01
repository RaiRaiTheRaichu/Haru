using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Server.Utils;

namespace Haru.Server.Controllers
{
    public class CustomizationStorageController : Controller
    {
        public override async Task Run(RouterContext context)
        {
            if (!context.Request.Url.LocalPath
                .Equals("/client/trading/customization/storage"))
            {
                return;
            }

            var data = ProfileService.GetCustomizationStorageModel();
            var body = new ResponseModel<CustomizationStorageModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context.Response, json);
        }
    }
}