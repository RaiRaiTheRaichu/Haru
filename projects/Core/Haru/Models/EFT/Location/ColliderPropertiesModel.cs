using Haru.Models.EFT.Generics;
using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct ColliderPropertiesModel
    {
        [JsonProperty("Center")]
        public Vector3<float> Center;

        [JsonProperty("Radius")]
        public int Radius;
    }
}