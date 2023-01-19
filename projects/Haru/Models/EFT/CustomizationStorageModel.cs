using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct CustomizationStorageModel
    {
        [JsonProperty("_id")]
        public string ProfileId;

        [JsonProperty("suits")]
        public string[] Suits;
    }
}