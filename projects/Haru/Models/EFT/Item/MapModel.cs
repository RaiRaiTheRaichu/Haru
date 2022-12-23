using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct MapModel
    {
        [JsonProperty("Markers")]
        public MarkersModel[] ItemMarkers;
    }
}
