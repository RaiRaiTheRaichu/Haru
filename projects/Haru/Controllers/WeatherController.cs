using Haru.Http;
using Haru.Models;
using Haru.Models.EFT;
using Haru.Models.EFT.Weather;
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

        public override void Run(RouterContext context)
        {
            var data = _weatherService.GetWeather();
            var body = new ResponseModel<WeatherModel>(data);
            var json = _json.Serialize(body);
            SendJson(context, json);
        }
    }
}