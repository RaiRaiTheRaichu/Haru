using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct BotLimitModel
    {
        [JsonProperty("min")]
        public int min;

        [JsonProperty("max")]
        public int max;

		[JsonProperty("WildSpawnType")]
        public string WildSpawnType;
    }
}