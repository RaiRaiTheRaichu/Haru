using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct OfflineStartModel
    {
        [JsonProperty("locationName")]
        public string LocationName;

        [JsonProperty("startTime")]
        public double StartTime;

        [JsonProperty("dateTime")]
        public string DateTime;

        [JsonProperty("gameSettings")]
        public GameSettingsModel GameSettings;
    }
}