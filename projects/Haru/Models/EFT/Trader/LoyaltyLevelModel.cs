using Newtonsoft.Json;

namespace Haru.Models.EFT.Trader
{
    public struct LoyaltyLevelModel
    {
        [JsonProperty("minLevel")]
        public int MinLevel;

        [JsonProperty("minSalesSum")]
        public int MinSalesSum;

        [JsonProperty("minStanding")]
        public float MinStanding;

        [JsonProperty("buy_price_coef")]
        public int BuyPriceCoef;

        [JsonProperty("repair_price_coef")]
        public string RepairPriceCoef;

        [JsonProperty("insurance_price_coef")]
        public int InsurancePriceCoef;

        [JsonProperty("exchange_price_coef")]
        public int ExchangePriceCoef;

        [JsonProperty("heal_price_coef")]
        public int HealPriceCoef;
    }
}