using Newtonsoft.Json;

namespace Haru.Models.EFT.Game
{
    public struct ProfileSelectModel
    {
        [JsonProperty("status")]
        public string Status;

        [JsonProperty("notifier")]
        public NotifierServerModel NotifierServerModel;
    }
}