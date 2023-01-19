using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct GameSettingsModel
    {
        [JsonProperty("timeAndWeatherSettings")]
        public TimeWeatherSettingsModel TimeWeatherSettings;

        [JsonProperty("botsSettings")]
        public BotsSettingsModel BotsSettings;

        [JsonProperty("waveSettings")]
        public WaveSettingsModel WaveSettings;
    }
}