using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct PositionModel
    {
        [JsonProperty("x")]
        public float x;

        [JsonProperty("y")]
        public float y;

		[JsonProperty("z")]
        public float z;
    }
}