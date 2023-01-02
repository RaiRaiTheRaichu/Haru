using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct BossLocationSpawnModel
    {
        [JsonProperty("BossName")]
        public string BossName;

        [JsonProperty("BossChance")]
        public int BossChance;

        [JsonProperty("BossZone")]
        public string BossZone;

        [JsonProperty("BossPlayer")]
        public bool IsBossPlayer;

        [JsonProperty("BossDifficult")]
        public string BossDifficulty;

        [JsonProperty("BossEscortType")]
        public string BossEscortType;

        [JsonProperty("BossEscortDifficult")]
        public string BossEscortDifficulty;

        [JsonProperty("BossEscortAmount")]
        public string BossEscortAmount;

        [JsonProperty("Time")]
        public int Time;

        [JsonProperty("RandomTimeSpawn")]
        public bool IsRandomTimeSpawn;
    }
}