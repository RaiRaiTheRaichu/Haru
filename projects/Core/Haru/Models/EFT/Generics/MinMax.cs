using Newtonsoft.Json;

namespace Haru.Models.EFT.Generics
{
    public struct MinMax<T>
    {
        [JsonProperty("min")]
        public T Min;

        [JsonProperty("max")]
        public T Max;
    }
}