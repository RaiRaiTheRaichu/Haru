using Newtonsoft.Json;

namespace Haru.Models.EFT.Trader
{
    public struct InsuranceModel
    {
        [JsonProperty("availability")]
        public bool Availability;

        [JsonProperty("min_payment")]
        public int MinPayment;

        [JsonProperty("min_return_hour")]
        public int MinReturnHour;

        [JsonProperty("max_return_hour")]
        public int MaxReturnHour;

        [JsonProperty("max_storage_time")]
        public int MaxStorageTime;

        [JsonProperty("excluded_category")]
        public string[] ExcludedCategories;
    }
}