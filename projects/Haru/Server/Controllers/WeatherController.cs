using System.Threading.Tasks;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Weather;
using Haru.Server.Helpers;
using Haru.Server.Http;
using Haru.Server.Services;
using Haru.Utils;

namespace Haru.Server.Controllers
{
    public class WeatherController : Controller
    {
        public override bool IsMatch(RouterContext context)
        {
            return RequestHelper.GetPath(context.Request)
                == "/client/weather";
        }

        public override async Task Run(RouterContext context)
        {
            var data = WeatherService.GetWeather();
            var body = new ResponseModel<WeatherModel>(data);
            var json = Json.Serialize(body);
            await SendJson(context, json);
        }
    }
}