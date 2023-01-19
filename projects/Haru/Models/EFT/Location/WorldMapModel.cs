using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct WorldMapModel
    {
        [JsonProperty("locations")]
        public Dictionary<string, LocationModel> Locations;

        [JsonProperty("paths")]
        public PathModel[] Paths;
    }
}