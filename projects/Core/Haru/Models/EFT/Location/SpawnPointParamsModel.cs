using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct SpawnPointParamsModel
    {
        [JsonProperty("Id")]
        public string Id;

		[JsonProperty("Position")]
        public PositionModel[] Position;

		[JsonProperty("Rotation")]
        public float Rotation;

		[JsonProperty("Sides")]
        public string[] Sides;

		[JsonProperty("Categories")]
        public string[] Categories;

		[JsonProperty("Infiltration")]
        public string Infiltration;

		[JsonProperty("DelayToCanSpawnSec")]
        public int DelayToCanSpawnSec;

		[JsonProperty("ColliderParams")]
        public ColliderParametersModel[] ColliderParams;

		[JsonProperty("BotZoneName")]
        public string BotZoneName;
    }
}