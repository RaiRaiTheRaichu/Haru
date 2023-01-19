using Newtonsoft.Json;

namespace Haru.Models.EFT.Locale
{
    public struct NameModel
    {
        [JsonProperty("ShortName")]
        public string ShortName;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Description")]
        public string Description;
    }
}