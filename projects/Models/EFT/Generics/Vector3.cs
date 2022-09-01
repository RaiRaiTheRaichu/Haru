using Newtonsoft.Json;

namespace Haru.Models.EFT.Generics
{
    public struct Vector3<T>
    {
        [JsonProperty("x")]
        public T X;

        [JsonProperty("Y")]
        public T Y;

        [JsonProperty("z")]
        public T Z;
    }
}