using Haru.Models.EFT.Generics;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct SpawnPointModel
    {
        [JsonProperty("Id")]
        public string Id;

        [JsonProperty("Position")]
        public Vector3<float> Position;

        [JsonProperty("Rotation")]
        public float Rotation;

        [JsonProperty("Sides")]
        public string[] Sides;

        [JsonProperty("Categories")]
        public string[] Categories;

        [JsonProperty("Infiltration")]
        public string Infiltration;

        [JsonProperty("DelayToCanSpawnSec")]
        public float SpawnDelay;

        [JsonProperty("ColliderParams")]
        public ColliderParametersModel ColliderParameters;

        [JsonProperty("BotZoneName")]
        public string BotZoneName;
    }
}