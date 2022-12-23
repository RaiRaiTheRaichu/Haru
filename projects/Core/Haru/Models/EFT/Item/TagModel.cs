using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct TagModel
    {
        [JsonProperty("Color")]
        public int Color;

        [JsonProperty("Name")]
        public string Name;
    }
}
