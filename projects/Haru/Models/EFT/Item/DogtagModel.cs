using Newtonsoft.Json;

namespace Haru.Models.EFT.Item
{
    public struct DogtagModel
    {
        [JsonProperty("AccountId")]
        public string AccountId;

        [JsonProperty("ProfileId")]
        public string ProfileId;

        [JsonProperty("Nickname")]
        public string Nickname;

        [JsonProperty("Side")]
        public string Side;

        [JsonProperty("Level")]
        public int Level;

        [JsonProperty("Time")]
        public string Time;

        [JsonProperty("Status")]
        public string Status;

        [JsonProperty("KillerAccountId")]
        public string KillerAccountId;

        [JsonProperty("KillerProfileId")]
        public string KillerProfileId;

        [JsonProperty("KillerName")]
        public string KillerName;

        [JsonProperty("WeaponName")]
        public string WeaponName;
    }
}
