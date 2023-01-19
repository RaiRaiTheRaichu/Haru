using Newtonsoft.Json;

namespace Haru.Models.EFT.Game
{
    public struct KeepaliveModel
    {
        [JsonProperty("msg")]
        public string Message;

        [JsonProperty("utc_time")]
        public long Timestamp;
    }
}