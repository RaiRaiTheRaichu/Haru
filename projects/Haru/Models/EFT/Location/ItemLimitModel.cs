using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct ItemLimitModel
    {
        [JsonProperty("TemplateId")]
        public string ItemTemplateId;

        [JsonProperty("value")]
        public int Value;
    }
}