using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct ProfileSelectModel
    {
        [JsonProperty("uid")]
        public string ProfileId;
    }
}