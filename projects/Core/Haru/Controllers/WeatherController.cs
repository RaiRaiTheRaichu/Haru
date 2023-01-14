using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Weather;
using Haru.Http;
using Haru.Services;

namespace Haru.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        public override bool IsMatch(RouterContext context)
        {
            return _requestHelper.GetPath(context.Request) == "/client/weather";
        }

        public override void Run(RouterContext context)
        {
            var data = _weatherService.GetWeather();
            var body = new ResponseModel<WeatherModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}