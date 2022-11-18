using Newtonsoft.Json;

namespace Haru.Models.EFT.Weather
{
    public struct WeatherSettingsModel
    {
        [JsonProperty("timestamp")]
        public long Timestamp;

        [JsonProperty("cloud")]
        public float Cloud;

        [JsonProperty("wind_speed")]
        public int WindSpeed;

        [JsonProperty("wind_direction")]
        public int WindDirection;

        [JsonProperty("wind_gustiness")]
        public float WindGustiness;
 
        [JsonProperty("rain")]
        public int Rain;

        [JsonProperty("rain_intensity")]
        public float RainIntensity;

        [JsonProperty("fog")]
        public float Fog;

        [JsonProperty("temp")]
        public int Temperature;

        [JsonProperty("pressure")]
        public int Pressure;

        [JsonProperty("date")]
        public string Date;

        [JsonProperty("time")]
        public string Time;
    }
}
