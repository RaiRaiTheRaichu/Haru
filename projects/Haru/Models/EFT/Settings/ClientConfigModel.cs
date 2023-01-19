using Newtonsoft.Json;

namespace Haru.Models.EFT.Settings
{
    public struct ClientConfigModel
    {
        [JsonProperty("MemoryManagementSettings")]
        public MemoryModel MemoryManagementSettings;

        [JsonProperty("ReleaseProfiler")]
        public ProfilerModel ReleaseProfiler;

        [JsonProperty("FramerateLimit")]
        public FramerateModel FramerateLimit;

        [JsonProperty("ClientSendRateLimit")]
        public int ClientSendRateLimit;

        [JsonProperty("TurnOffLogging")]
        public bool TurnOffLogging;

        [JsonProperty("NVidiaHighlights")]
        public bool NVidiaHighlights;
        
        [JsonProperty("WebDiagnosticsEnabled")]
        public bool WebDiagnosticsEnabled;

        [JsonProperty("KeepAliveInterval")]
        public int KeepAliveInterval;

        [JsonProperty("GroupStatusInterval")]
        public int GroupStatusInterval;

        [JsonProperty("PingServersInterval")]
        public int PingServersInterval;

        [JsonProperty("PingServerResultSendInterval")]
        public int PingServerResultSendInterval;

        [JsonProperty("WeaponOverlapDistanceCulling")]
        public int WeaponOverlapDistanceCulling;

        [JsonProperty("FirstCycleDelaySeconds")]
        public int FirstCycleDelaySeconds;

        [JsonProperty("SecondCycleDelaySeconds")]
        public int SecondCycleDelaySeconds;

        [JsonProperty("NextCycleDelaySeconds")]
        public int NextCycleDelaySeconds;

        [JsonProperty("AdditionalRandomDelaySeconds")]
        public int AdditionalRandomDelaySeconds;

        [JsonProperty("Mark502and504AsNonImportant")]
        public bool Mark502and504AsNonImportant;

        [JsonProperty("DefaultRetriesCount")]
        public int DefaultRetriesCount;

        [JsonProperty("CriticalRetriesCount")]
        public int CriticalRetriesCount;

        [JsonProperty("AFKTimeoutSeconds")]
        public int AFKTimeoutSeconds;
    }
}