using Newtonsoft.Json;

namespace Haru.Models.EFT.Location
{
    public struct ColliderParametersModel
    {
        [JsonProperty("_parent")]
        public string Parent;

        [JsonProperty("_props")]
        public ColliderPropertiesModel Properties;
    }
}