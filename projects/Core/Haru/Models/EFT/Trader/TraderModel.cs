using Newtonsoft.Json;

namespace Haru.Models.EFT.Trader
{
    public struct TraderModel
    {
        [JsonProperty("_id")]
        public string TraderId;

        [JsonProperty("customization_seller")]
        public bool IsCustomizationSeller;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("surname")]
        public string Surname;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("location")]
        public string Location;

        [JsonProperty("avatar")]
        public string Avatar;

        [JsonProperty("balance_rub")]
        public int BalanceRoubles;

        [JsonProperty("balance_dol")]
        public int BalanceDollars;

        [JsonProperty("balance_eur")]
        public int BalanceEuros;

        [JsonProperty("unlockedByDefault")]
        public bool IsUnlockedByDefault;

        [JsonProperty("discount")]
        public string Discount;

        [JsonProperty("discount_end")]
        public long DiscountEnd;

        [JsonProperty("buyer_up")]
        public bool IsBuyerUp;

        [JsonProperty("currency")]
        public string Currency;

        [JsonProperty("nextResupply")]
        public long NextResupply;

        [JsonProperty("repair")]
        public RepairModel Repair;

        [JsonProperty("insurance")]
        public InsuranceModel Insurance;

        [JsonProperty("medic")]
        public bool IsMedic;

        [JsonProperty("gridHeight")]
        public int GridHeight;

        [JsonProperty("loyaltyLevels")]
        public LoyaltyLevelModel[] LoyaltyLevels;

        [JsonProperty("sell_category")]
        public string[] SellCategories;
    }
}