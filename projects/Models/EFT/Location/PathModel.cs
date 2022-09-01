using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct PathModel
    {
        // note: value is LocationId
        [JsonProperty("Source")]
        public string Source;

        // note: value is LocationId
        [JsonProperty("Destination")]
        public string Destination;
    }
}