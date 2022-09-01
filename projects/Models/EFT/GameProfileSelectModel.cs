using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct GameProfileSelectModel
    {
        [JsonProperty("status")]
        public string Status;

        [JsonProperty("notifier")]
        public NotifierServerModel NotifierServerModel;
    }
}