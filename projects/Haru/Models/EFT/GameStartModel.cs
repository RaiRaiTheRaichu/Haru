using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct GameStartModel
    {
        [JsonProperty("utc_time")]
        public long LoginTime;
    }
}