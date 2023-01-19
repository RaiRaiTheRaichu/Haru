using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct VersionValidateModel
    {
        [JsonProperty("version")]
        public VersionModel Version;

        [JsonProperty("develop")]
        public bool IsDevelop;
    }
}