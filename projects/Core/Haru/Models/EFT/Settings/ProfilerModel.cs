using Newtonsoft.Json;

namespace Haru.Models.EFT.Settings
{
    public struct MemoryModel
    {
        [JsonProperty("HeapPreAllocationEnabled")]
        public bool HeapPreAllocationEnabled;

        [JsonProperty("HeapPreAllocationMB")]
        public int HeapPreAllocationMB;

        [JsonProperty("OverrideRamCleanerSettings")]
        public bool OverrideRamCleanerSettings;

        [JsonProperty("RamCleanerEnabled")]
        public bool RamCleanerEnabled;

        [JsonProperty("GigabytesRequiredToDisableGCDuringRaid")]
        public int GigabytesRequiredToDisableGCDuringRaid;

        [JsonProperty("AggressiveGC")]
        public bool AggressiveGC;
    }
}