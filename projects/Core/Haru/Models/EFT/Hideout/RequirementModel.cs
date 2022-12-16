using Newtonsoft.Json;

namespace Haru.Models.EFT.Hideout
{
    public struct RequirementModel
    {
        [JsonProperty("templateId")]
        public string ItemId;

        [JsonProperty("count")]
        public int Count;

        [JsonProperty("isFunctional")]
        public bool IsFunctional;

        [JsonProperty("type")]
        public string Type;
    }
}