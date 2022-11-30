using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct WaveSettingsModel
    {
        [JsonProperty("botDifficulty")]
        public string BotDifficulty;

        [JsonProperty("isBosses")]
        public bool IsBosses;

        [JsonProperty("isTaggedAndCursed")]
        public bool IsTaggedAndCursed;

        [JsonProperty("wavesBotAmount")]
        public string WavesBotAmount;
    }
}