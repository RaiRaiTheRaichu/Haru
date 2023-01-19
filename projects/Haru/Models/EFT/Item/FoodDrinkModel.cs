using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct FoodDrinkModel
    {
        [JsonProperty("HpPercent")]
        public int HpPercent;
    }
}
