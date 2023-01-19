using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct BotsSettingsModel
    {
        [JsonProperty("isEnabled")]
        public bool IsEnabled;

        [JsonProperty("isScavWars")]
        public bool IsScavWars;

        [JsonProperty("botAmount")]
        public string BotAmount;
    }
}