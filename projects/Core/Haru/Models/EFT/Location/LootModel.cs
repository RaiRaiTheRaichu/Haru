using Haru.Models.EFT.Generics;
using Haru.Models.EFT.Item;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct LootModel
    {
        [JsonProperty("id")]
        public string LootId;

        [JsonProperty("IsStatic")]
        public bool IsStatic;

        [JsonProperty("useGravity")]
        public bool UseGravity;

        [JsonProperty("randomRotation")]
        public bool IsRandomRotation;

        [JsonProperty("Position")]
        public Vector3<float> Position;

        [JsonProperty("Rotation")]
        public Vector3<float> Rotation;

        // always false?
        [JsonProperty("IsGroupPosition")]
        public bool IsGroupPosition;

        // always empty?, todo
        [JsonProperty("GroupPositions")]
        public object[] GroupPositions;

        // always false?
        [JsonProperty("IsAlwaysSpawn")]
        public bool IsAlwaysSpawn;

        [JsonProperty("Root")]
        public string Root;

        [JsonProperty("Items")]
        public ItemModel Items;
    }
}