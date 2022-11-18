using Newtonsoft.Json;

namespace Haru.Models.EFT.Weather
{
    public struct WeatherModel
    {
        [JsonProperty("weather")]
        public WeatherSettingsModel Weather;

        [JsonProperty("date")]
        public string Date;

        [JsonProperty("time")]
        public string Time;

        [JsonProperty("acceleration")]
        public int Acceleration;
    }
}
