using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct TimeWeatherSettingsModel
    {
        [JsonProperty("isRandomTime")]
        public bool IsRandomTime;

        [JsonProperty("isRandomWeather")]
        public bool IsRandomWeather;
    }
}