using Newtonsoft.Json;

namespace Haru.Models.EFT.Notification
{
    public struct PingModel
    {
        [JsonProperty("type")]
        public const string Type = "ping";

        [JsonProperty("eventId")]
        public const string EventId = "ping";
    }
}