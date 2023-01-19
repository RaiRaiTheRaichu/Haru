using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct LocalLootModel
    {
        [JsonProperty("crc")]
        public int Crc;

        [JsonProperty("locationId")]
        public string LocationId;

        [JsonProperty("variantId")]
        public int Variant;
    }
}