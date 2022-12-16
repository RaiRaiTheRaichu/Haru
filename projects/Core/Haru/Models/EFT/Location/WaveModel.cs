using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct WaveModel
    {
        [JsonProperty("number")]
        public int Number;

        [JsonProperty("time_min")]
        public int TimeMin;

        [JsonProperty("time_max")]
        public int TimeMax;

        [JsonProperty("slots_min")]
        public int SlotsMin;

        [JsonProperty("slots_max")]
        public int SlotsMax;

        [JsonProperty("SpawnPoints")]
        public string SpawnPoints;

        [JsonProperty("BotSide")]
        public string BotSide;

        [JsonProperty("BotPreset")]
        public string BotPreset;

        [JsonProperty("isPlayers")]
        public bool IsPlayer;

        [JsonProperty("WildSpawnType")]
        public string WildSpawnType;
    }
}