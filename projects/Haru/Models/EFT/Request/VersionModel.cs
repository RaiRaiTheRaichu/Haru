using Newtonsoft.Json;

namespace Haru.Models.EFT.Request
{
    public struct VersionModel
    {
        [JsonProperty("major")]
        public string Major;

        [JsonProperty("minor")]
        public string Minor;

        [JsonProperty("game")]
        public string Game;

        [JsonProperty("backend")]
        public string Backend;

        [JsonProperty("taxonomy")]
        public string Taxonomy;
    }
}