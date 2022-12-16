using Newtonsoft.Json;

namespace Haru.Models.EFT.Bundle
{
    public struct ResourceModel
    {
        [JsonProperty("path")]
        public string Path;

        [JsonProperty("rcid")]
        public string ResourceId;
    }
}