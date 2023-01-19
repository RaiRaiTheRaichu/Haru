using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct RepairableModel
    {
        [JsonProperty("MaxDurability")]
        public float MaxDurability;

        [JsonProperty("Durability")]
        public float Durability;
    }
}
