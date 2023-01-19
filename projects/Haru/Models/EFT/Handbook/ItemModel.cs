using Newtonsoft.Json;

namespace Haru.Models.EFT.Handbook
{
    public struct ItemModel
    {
        [JsonProperty("Id")]
        public string Id;

        [JsonProperty("ParentId")]
        public string ParentId;

        [JsonProperty("Price")]
        public int Price;
    }
}