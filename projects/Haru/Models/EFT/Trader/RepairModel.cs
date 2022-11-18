using Newtonsoft.Json;

namespace Haru.Models.EFT.Trader
{
    public struct RepairModel
    {
        [JsonProperty("availability")]
        public bool Availability;

        [JsonProperty("quality")]
        public string Quality;

        [JsonProperty("excluded_id_list")]
        public string[] ExcludedIds;

        [JsonProperty("excluded_category")]
        public string[] ExcludedCategories;

        [JsonProperty("currency")]
        public string CurrencyId;

        [JsonProperty("currency_coefficient")]
        public int CurrencyCoef;
    }
}