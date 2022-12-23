using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct LocationModel
    {
        [JsonProperty("x")]
        public int X;

        [JsonProperty("y")]
        public int Y;

        [JsonProperty("r")]
        public string Rotation;     // NOTE: Can also be an int

        [JsonProperty("isSearched")]
        public bool? IsSearched;
    }
}
