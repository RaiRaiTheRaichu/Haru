using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct FoldableModel
    {
        [JsonProperty("Folded")]
        public bool Folded;
    }
}
