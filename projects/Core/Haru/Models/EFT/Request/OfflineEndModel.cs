using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct OfflineEndModel
    {
        [JsonProperty("crc")]
        public int Crc;

        [JsonProperty("exitStatus")]
        public string ExitStatus;

        [JsonProperty("exitName")]
        public string ExitName;

        [JsonProperty("raidSeconds")]
        public float RaidSeconds;
    }
}