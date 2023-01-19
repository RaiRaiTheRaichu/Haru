using Newtonsoft.Json;

namespace Haru.Models.EFT.Game
{
    public struct StartModel
    {
        [JsonProperty("utc_time")]
        public long LoginTime;
    }
}