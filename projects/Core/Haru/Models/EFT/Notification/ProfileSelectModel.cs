using Newtonsoft.Json;

namespace Haru.Models.EFT.Notification
{
    public struct ProfileSelectModel
    {
        [JsonProperty("status")]
        public string Status;

        [JsonProperty("notifier")]
        public NotifierModel NotificationServer;

        [JsonProperty("notifierServer")]
        public string Unused;
    }
}