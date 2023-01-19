using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct AirdropParametersModel
    {
        [JsonProperty("PlaneAirdropStartMin")]
        public int PlaneAirdropStartMin;

        [JsonProperty("PlaneAirdropStartMax")]
        public int PlaneAirdropStartMax;

        [JsonProperty("PlaneAirdropEnd")]
        public int PlaneAirdropEnd;

        [JsonProperty("PlaneAirdropChance")]
        public float PlaneAirdropChance;

        [JsonProperty("PlaneAirdropMax")]
        public int PlaneAirdropMax;

		[JsonProperty("PlaneAirdropCooldownMin")]
        public int PlaneAirdropCooldownMin;

		[JsonProperty("PlaneAirdropCooldownMax")]
        public int PlaneAirdropCooldownMax;

		[JsonProperty("AirdropPointDeactivateDistance")]
        public int AirdropPointDeactivateDistance;

		[JsonProperty("MinPlayersCountToSpawnAirdrop")]
        public int MinPlayersCountToSpawnAirdrop;

		[JsonProperty("UnsuccessfulTryPenalty")]
        public int UnsuccessfulTryPenalty;
    }
}