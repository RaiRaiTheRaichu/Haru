using Newtonsoft.Json;

namespace Haru.Models.EFT.Friend
{
    public struct InfoModel
    {
        [JsonProperty("Nickname")]
        public string Nickname;

        [JsonProperty("Side")]
        public string Side;

        [JsonProperty("Level")]
        public int Level;

        [JsonProperty("MemberCategory")]
        public int MemberCategory;
    }
}
