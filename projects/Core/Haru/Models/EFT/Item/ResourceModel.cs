using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct ResourceModel
    {
        [JsonProperty("Value")]
        public float Value;

        [JsonProperty("UnitsConsumed")]
        public float? UnitsConsumed;
    }
}
