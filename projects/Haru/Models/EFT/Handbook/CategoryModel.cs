using Newtonsoft.Json;

namespace Haru.Models.EFT.Handbook
{
    public struct CategoryModel
    {
        [JsonProperty("Id")]
        public string Id;

        [JsonProperty("ParentId")]
        public string ParentId;

        [JsonProperty("Icon")]
        public string Icon;

        [JsonProperty("Color")]
        public string Color;

        [JsonProperty("Order")]
        public string Order;
    }
}