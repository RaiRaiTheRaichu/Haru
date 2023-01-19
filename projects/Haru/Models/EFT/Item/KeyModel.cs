using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct KeyModel
    {
        [JsonProperty("NumberOfUsages")]
        public int NumberOfUsages;
    }
}
