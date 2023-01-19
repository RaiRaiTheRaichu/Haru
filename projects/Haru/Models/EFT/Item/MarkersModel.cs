using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct MarkersModel
    {
        [JsonProperty("Type")]
        public string Type;

        [JsonProperty("X")]
        public int X;

        [JsonProperty("Y")]
        public int Y;

        [JsonProperty("Note")]
        public string Note;
    }
}
