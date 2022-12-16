using Newtonsoft.Json;

namespace Haru.Models.EFT.Notification
{
    public struct NotifierModel
    {
        [JsonProperty("server")]
        public string Server;

        [JsonProperty("channel_id")]
        public string ChannelId;
        
        [JsonProperty("url")]
        public string Url;

        [JsonProperty("notifierServer")]
        public string HttpUrl;

        [JsonProperty("ws")]
        public string WebSocketUrl;

        public NotifierModel(string sessionId, string httpUrl, string wsUrl)
        {
            Server = wsUrl;
            ChannelId = sessionId;
            Url = string.Empty;
            HttpUrl = $"{httpUrl}/push/notifier/get/{sessionId}";
            WebSocketUrl = $"{wsUrl}push/notifier/getwebsocket/{sessionId}";
        }
    }
}