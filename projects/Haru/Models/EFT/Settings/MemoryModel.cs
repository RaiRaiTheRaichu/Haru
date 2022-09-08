using Newtonsoft.Json;

namespace Haru.Models.EFT.Settings
{
    public struct ProfilerModel
    {
        [JsonProperty("Enabled")]
        public bool Enabled;

        [JsonProperty("RecordTriggerValue")]
        public int RecordTriggerValue;

        [JsonProperty("MaxRecords")]
        public int MaxRecords;
    }
}