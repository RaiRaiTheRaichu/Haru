using Newtonsoft.Json;

namespace Haru.Models.EFT.Game
{
    public struct CheckVersionModel
    {
        [JsonProperty("isvalid")]
        public bool IsValid;

        [JsonProperty("latestVersion")]
        public string LatestVersion;
    }
}