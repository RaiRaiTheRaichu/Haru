using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct NameLocaleModel
    {
        [JsonProperty("ShortName")]
        public string ShortName;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Description")]
        public string Description;
    }
}