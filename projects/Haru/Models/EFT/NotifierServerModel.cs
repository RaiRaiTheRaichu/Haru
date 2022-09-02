using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct NotifierServerModel
    {
        [JsonProperty("server")]
        public string Server;

        [JsonProperty("channel_id")]
        public string ChannelId;

        // unused?
        [JsonProperty("url")]
        public string Url;

        [JsonProperty("notifierServer")]
        public string HttpUrl;

        [JsonProperty("ws")]
        public string WebSocketUrl;

        public NotifierServerModel(string sessionId, string url)
        {
            Server = url;
            ChannelId = sessionId;
            Url = string.Empty;
            HttpUrl = $"{url}/push/notifier/get/{sessionId}";
            WebSocketUrl = $"{url}/push/notifier/getwebsocket/{sessionId}";
        }
    }
}