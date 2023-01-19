using Newtonsoft.Json;

namespace Haru.Models.EFT.Mail
{
    public struct MessageModel
    {
        [JsonProperty("dt")]
        public long Timestamp;

        [JsonProperty("type")]
        public int Type;

        [JsonProperty("text")]
        public string Text;

        // trader or friend
        [JsonProperty("uid")]
        public string UserId;

        [JsonProperty("templateId")]
        public string TraderMessageId;
    }
}
