using Newtonsoft.Json;
using Haru.Models.EFT.Generics;

namespace Haru.Models.EFT.Hideout
{
    public struct EndProductsModel
    {
        [JsonProperty("Rare")]
        public MinMax<string> Rare;

        [JsonProperty("Common")]
        public MinMax<string> Common;

        [JsonProperty("Superrare")]
        public MinMax<string> SuperRare;
    }
}