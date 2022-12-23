using System.Threading.Tasks;
using Haru.Framework.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Weather;
using Haru.Framework.Helpers;
using Haru.Framework.Http;
using Haru.Services;
using Haru.Framework.Utils;

namespace Haru.Controllers
{
    public class WeatherController : Controller
    {
        private readonly RequestHelper _requestHelper;
        private readonly Json _json;
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _requestHelper = new RequestHelper();
            _json = new Json();
            _weatherService = new WeatherService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/weather";
        }

        public override async Task Run(RouterContext context)
        {
            var data = _weatherService.GetWeather();
            var body = new ResponseModel<WeatherModel>(data);
            var json = _json.Serialize(body);
            await SendJson(context, json);
        }
    }
}